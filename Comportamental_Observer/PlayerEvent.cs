using System;

public class Player{
    public event Action OnPlayerDeath;
    // Evento que sera disparado quando o jogador morrer
    
    public int Life = 3;

    //Metodo para testar o sistema de dano
    public void TakeDamage(int damage){
        Life -= damage;
        Console.WriteLine($"Player recebeu dano. Vida atual: {Life}");
        if (Life <= 0){
            Die();
        }
    }

    private void Die(){
        Console.WriteLine("Player morreu.");

        // Ativar os observadores
        OnPlayerDeath?.Invoke();
    }
}

// Classes do observadores

// =============================
// OBSERVER 1
// =============================
public class UIManager{
    public void ShowGameOverScreen(){
        Console.WriteLine("UI: Exibindo tela de Game Over.");
    }
}

// =============================
// OBSERVER 2
// =============================
public class AudioManager{
    public void PlayDeathSound(){
        Console.WriteLine("Audio: Tocando som de morte.");
    }
}

// =============================
// OBSERVER 3
// =============================
public class SaveSystem{
    public void SavePlayerData(){
        Console.WriteLine("SaveSystem: Salvando dados do jogador.");
    }
}

// =============================
// MAIN
// =============================
public class Program{
    public static void Main(){
        Player player = new Player();

        UIManager ui = new UIManager();
        AudioManager audio = new AudioManager();
        SaveSystem save = new SaveSystem();

        // Inscrevendo observers no evento
        // Atribuir o evento do OnPlayerDeath ao ClasseObserver.Metodo
        player.OnPlayerDeath += ui.ShowGameOverScreen;
        player.OnPlayerDeath += audio.PlayDeathSound;
        player.OnPlayerDeath += save.SavePlayerData;

        // Simulação de dano
        player.TakeDamage(1);
        player.TakeDamage(1);
        player.TakeDamage(1);
    }
}


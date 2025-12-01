namespace Tiroksin.Domain.Enums;

public enum PlayerStatus
{
    Waiting = 0,    // Oyuncu bekleniyor
    Ready = 1,      // Oyuncu hazır
    Playing = 2,    // Oyun oynuyor
    Finished = 3,   // Oyunu bitirdi
    Disconnected = 4 // Bağlantı koptu
}

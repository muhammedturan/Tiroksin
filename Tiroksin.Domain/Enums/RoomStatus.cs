namespace Tiroksin.Domain.Enums;

public enum RoomStatus
{
    Waiting = 0,    // Oyuncular bekleniyor
    Ready = 1,      // Herkes hazır, başlatılabilir
    InProgress = 2, // Oyun devam ediyor
    Finished = 3,   // Oyun bitti
    Cancelled = 4   // İptal edildi
}

namespace Apka_Kursy.Entities;

public class Image
{
    public int Id { get; set; }
    public string Name { get; set; }
    public byte[] Data { get; set; } // Pole do przechowywania danych obrazu
}

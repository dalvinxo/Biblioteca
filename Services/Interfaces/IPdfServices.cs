namespace Biblioteca.Services;

public interface IPdfServices
{

    public byte[] GeneratePdf(string html);
    
}
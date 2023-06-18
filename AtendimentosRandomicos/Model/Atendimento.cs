namespace AtendimentosRandomicos.Model;

public class Atendimento
{
    public string SenhaAtendimento { get; set; }
    public int IdAtendimento { get; set; }
    public int IdHospital { get; set; }
    public int IdEspecialidade { get; set; }
    public int IdTriagem { get; set; }
    public int IdAssociado { get; set; }
    public int TempoAtendimento { get; set; }
}
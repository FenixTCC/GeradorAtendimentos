using AtendimentosRandomicos.Model;
using AtendimentosRandomicos.Connection;

namespace AtendimentosRandomicos.Insert;

public class InsertAtendimentos
{
    public static void GerarAtendimentoRandomico()
    {
        Atendimento atendimento = new Atendimento();

        do
        {
            atendimento.IdAtendimento++;

            atendimento.IdHospital = Rand.RandAtendimentos.RandomizarHospital();
            atendimento.IdEspecialidade = Rand.RandAtendimentos.RandomizarEspecialidade();
            atendimento.IdTriagem = Rand.RandAtendimentos.RandomizarTriagem();
            atendimento.IdAssociado = Rand.RandAtendimentos.RandomizarAssociado();

            atendimento.TempoAtendimento = Rand.RandAtendimentos.RandomizarTempoAtendimento(atendimento.IdTriagem);
            atendimento.TempoAtendimento = Rand.RandAtendimentos.RandomizarAtrasoAtendimento(atendimento.IdAtendimento, atendimento.IdHospital, atendimento.TempoAtendimento);

            atendimento.SenhaAtendimento = Rand.RandAtendimentos.RandomizarFormatarSenha(atendimento.IdEspecialidade, atendimento.IdHospital, atendimento.IdAtendimento);

            ConnectionDB.InsertToSqlDb(atendimento.SenhaAtendimento, atendimento.IdAtendimento, atendimento.IdHospital, atendimento.IdEspecialidade,
                                            atendimento.IdTriagem, atendimento.IdAssociado, atendimento.TempoAtendimento);

        } while (atendimento.IdHospital >= 1 && atendimento.IdHospital <= 6);
    }
}
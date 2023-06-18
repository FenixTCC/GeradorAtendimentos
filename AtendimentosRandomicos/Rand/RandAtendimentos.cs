namespace AtendimentosRandomicos.Rand;

public class RandAtendimentos
{
    public static int RandomizarHospital()
    {
        Random rand = new Random();
        int randHospital = rand.Next(1, 7);
        return randHospital;
    }

    public static int RandomizarEspecialidade()
    {
        Random rand = new Random();
        int randEspecialidade = rand.Next(1, 4);
        return randEspecialidade;
    }

    public static int RandomizarTriagem()
    {
        Random rand = new Random();
        int randTriagem = rand.Next(1, 11);
        int idTriagem;

        if (randTriagem >= 1 && randTriagem <= 6)
            idTriagem = 1;
        else if (randTriagem >= 7 && randTriagem <= 9)
            idTriagem = 2;
        else
            idTriagem = 3;

        return idTriagem;
    }

    public static int RandomizarAssociado()
    {
        Random rand = new Random();
        int randAssociado = rand.Next(1, 51);
        return randAssociado;
    }

    public static int RandomizarTempoAtendimento(int idTriagem)
    {
        Random rand = new Random();
        int randTempo;

        if (idTriagem == 1)
            randTempo = rand.Next(121, 241);
        else if (idTriagem == 2)
            randTempo = rand.Next(61, 121);
        else
            randTempo = rand.Next(11, 61);

        return randTempo;
    }

    public static int RandomizarAtrasoAtendimento(int idAtendimento, int idHospital, int tempoAtendimento)
    {
        Random rand = new Random();
        int randAtraso = rand.Next(30, 61);

        if (idAtendimento >= 1 && idAtendimento <= 180)
        {
            if (idHospital == 1 || idHospital == 3 || idHospital == 5)
                return tempoAtendimento + randAtraso;
        }

        if (idAtendimento >= 181 && idAtendimento <= 360)
        {
            if (idHospital == 2 || idHospital == 4 || idHospital == 6)
                return tempoAtendimento + randAtraso;
        }

        if (idAtendimento >= 361 && idAtendimento <= 540)
        {
            if (idHospital == 1 || idHospital == 3 || idHospital == 5)
                return tempoAtendimento + randAtraso;
        }

        if (idAtendimento >= 541 && idAtendimento <= 720)
        {
            if (idHospital == 2 || idHospital == 4 || idHospital == 6)
                return tempoAtendimento + randAtraso;
        }

        return tempoAtendimento;
    }

    public static string RandomizarFormatarSenha(int idEspecialidade, int idHospital, int idAtendimento)
    {
        Random rand = new Random();
        DateTime dtSenha = DateTime.Now;
        char espSenha;

        if (idEspecialidade >= 1 && idEspecialidade <= 7)
            espSenha = 'C';
        else if (idEspecialidade >= 8 && idEspecialidade <= 9)
            espSenha = 'O';
        else
            espSenha = 'P';

        return string.Format("{0}{1}.{2}{3}-{4}{5}", dtSenha.Year, dtSenha.DayOfYear, idHospital, idAtendimento, espSenha, rand.Next(100, 1000));
    }
}
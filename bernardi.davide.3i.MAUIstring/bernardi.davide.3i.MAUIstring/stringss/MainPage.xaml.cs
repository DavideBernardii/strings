using System.Runtime.InteropServices;

namespace stringss;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    static int Lunghezza(string TextIn)
    {
        char[] caratteri = TextIn.ToCharArray();
        int Valo = 0;

        foreach (char c in caratteri)
            Valo++;

        return Valo;
    }


    int Lettere(string TextIn)
    {
        char[] txtCharArray = TextIn.ToCharArray();
        int Valo = 0;

        for (int i = 0; i < Lunghezza(TextIn); i++)
            if ((txtCharArray[i] >= 'A') && (txtCharArray[i] <= 'Z') ||
               (txtCharArray[i] >= 'a') && (txtCharArray[i] <= 'z'))
                Valo++;

        return Valo;
    }

    int Letter(string TextIn)
    {
        char[] txtCharArray = TextIn.ToCharArray();
        int Valo = 0;

        for (int i = 0; i < Lunghezza(TextIn) - 1; i++)
            if (((txtCharArray[i + 1] >= 'A') && (txtCharArray[i + 1] <= 'Z') ||
               (txtCharArray[i + 1] >= 'a') && (txtCharArray[i + 1] <= 'z')) &&
               txtCharArray[i] == ' ')

                Valo++;
        Valo++;

        return Valo;
    }

    string Upertxt(string TextIn)
    {
        char[] txtCharArray = TextIn.ToCharArray();

        for (int i = 0; i < Lunghezza(TextIn); i++)
            if ((txtCharArray[i] >= 'a') && (txtCharArray[i] <= 'z'))
            {
                int charInt = (int)txtCharArray[i] & 0x5f;
                txtCharArray[i] = (char)charInt;
            }

        return new string(txtCharArray);
    }

    string Lowertxt(string TextIn)
    {
        char[] txtCharArray = TextIn.ToCharArray();

        for (int i = 0; i < Lunghezza(TextIn); i++)
            if ((txtCharArray[i] >= 'A') && (txtCharArray[i] <= 'Z'))
            {
                int x = (int)txtCharArray[i] | 0x20;
                txtCharArray[i] = (char)x;

            }

        return new string(txtCharArray);
    }

    string Riversetxt(string TextIn)
    {
        char[] txtCharArray = TextIn.ToCharArray();
        char[] txtCharArrayReverse = new char[Lunghezza(TextIn)];


        for (int i = 0; i < Lunghezza(TextIn); i++)
        {
            txtCharArrayReverse[i] = (char)txtCharArray[Lunghezza(TextIn) - i - 1];
        }

        return new string(txtCharArrayReverse);
    }

    bool Alfabeto(string TextIn)
    {
        char[] txtCharArray = TextIn.ToCharArray();

        for (int i = 0; i < Lunghezza(TextIn); i++)
            if (!((txtCharArray[i] >= 'a') && (txtCharArray[i] <= 'z') ||
               (txtCharArray[i] >= 'A') && (txtCharArray[i] <= 'Z')))
                return false;

        return true;
    }

    bool Alfanum(string TextIn)
    {
        char[] txtCharArray = TextIn.ToCharArray();

        for (int i = 0; i < Lunghezza(TextIn); i++)
            if (!((txtCharArray[i] >= 'a') && (txtCharArray[i] <= 'z') ||
               (txtCharArray[i] >= 'A') && (txtCharArray[i] <= 'Z') ||
               (txtCharArray[i] >= '1') && (txtCharArray[i] <= '9')))

                return false;

        return true;
    }

    bool Palindromo(string TextIn)
    {
        if (Lowertxt(TextIn) == Lowertxt(Riversetxt(TextIn)))
            return true;

        return false;
    }

    string Capit(string TextIn)
    {

        char[] txtCharArray = TextIn.ToCharArray();

        int charInt = (int)txtCharArray[0] & 0x5f;
        txtCharArray[0] = (char)charInt;

        for (int i = 0; i < Lunghezza(TextIn) - 1; i++)
            if (((txtCharArray[i + 1] >= 'a') && (txtCharArray[i + 1] <= 'z')) && txtCharArray[i] == ' ')
            {
                charInt = (int)txtCharArray[i + 1] & 0x5f;
                txtCharArray[i + 1] = (char)charInt;
            }
        return new string(txtCharArray);
    }

    private void ButStr(object sender, EventArgs e)
    {
        StringOut.Text =
            $"Maiuscolo: {Upertxt(StringIn.Text)} \n" +
            $"Minuscolo {Lowertxt(StringIn.Text)} \n" +
            $"Capitalized: {Capit(StringIn.Text)} \n" +
            $"Contiene solo lettere? {Alfabeto(StringIn.Text)} \n" +
            $"Contiene solo lettere e numeri? {Alfanum(StringIn.Text)} \n" +
            $"E' palidroma? {Palindromo(StringIn.Text)} \n" +
            $"Reverse: {Riversetxt(StringIn.Text)} \n" +
            $"Quante lettere: {Lettere(StringIn.Text)} \n" +
            $"Quante parole: {Letter(StringIn.Text)} \n";
    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


namespace jogoDeCartas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String Naipes="" ;

            String[] naipesdojogador1 = new String[5];
            int[] cartasDOsJogador1 = new int[5];
            String[] naipesdojogador2 = new String[5];
            int[] cartasDOsJogador2 = new int[5];

            String ParaJS = "";
            
            // gerar naipes e cartas aleatorias para o jogador 1

            for (int i = 0; i < 5; i++)
            {
                Boolean verificar = true; 
                int numeroAlea= numeroAleatorio().Next(1,5);

                if( numeroAlea==1 )   { Naipes="c";}
                if( numeroAlea==2 )   { Naipes="e";}
                if( numeroAlea==3 )   { Naipes="o";}
                if( numeroAlea==4 )   { Naipes="p";}

                naipesdojogador1[i] = Naipes;

                numeroAlea = numeroAleatorio().Next(2, 15);

                cartasDOsJogador1[i] = numeroAlea;

                        //verificar se as cartas se repetem.
                for (int k = 0; k < i; k++)
                {
                    if( naipesdojogador1[i]==naipesdojogador1[k] && cartasDOsJogador1[i] ==  cartasDOsJogador1[k])
                    {
                    --i;
                    verificar = false;
                    break;
                    }
                }


             if(verificar)
                ParaJS += naipesdojogador1[i] + cartasDOsJogador1[i] + "~";
            }



            // gerar naipes e cartas aleatorias para o jogador 2

            for (int i = 0; i < 5; i++)
            {
                Boolean verificar = true; 
                int numeroAlea = numeroAleatorio().Next(1, 5);

                if (numeroAlea == 1) { Naipes = "c"; }
                if (numeroAlea == 2) { Naipes = "e"; }
                if (numeroAlea == 3) { Naipes = "o"; }
                if (numeroAlea == 4) { Naipes = "p"; }

                naipesdojogador2[i] = Naipes;

                numeroAlea = numeroAleatorio().Next(2, 15);

                cartasDOsJogador2[i] = numeroAlea;

                            //verificar se as cartas se repetem.
                for (int k = 0; k < i; k++)
                {
                    if (naipesdojogador2[i] == naipesdojogador2[k] && cartasDOsJogador2[i] == cartasDOsJogador2[k])
                    {
                        i--;
                        verificar = false;
                        break;
                    }
                }

                for (int k = 0; k < 5; k++)
                {

                    if (naipesdojogador2[i] == naipesdojogador1[k] && cartasDOsJogador2[i] == cartasDOsJogador1[k])
                    {
                        i--;
                        verificar = false;
                        break;
                    }
                }


                if (verificar)
                 ParaJS += naipesdojogador2[i] + cartasDOsJogador2[i] + "~";
           }


            Array.Sort(cartasDOsJogador1);
            Array.Sort(cartasDOsJogador2);

            // chamar a função para obter o resultado
            int maoDoJogador1 = verificarResultado(cartasDOsJogador1,naipesdojogador1);
            int maoDoJogador2 = verificarResultado(cartasDOsJogador2, naipesdojogador2);

            Label2.Text = "" + maoDoJogador1;
            Label3.Text = "" + maoDoJogador2;

            // verificar qual mão possui as maiores cartas caso empate
            if (maoDoJogador1 == 1 && maoDoJogador2 == 1)
            {
                Array.Sort(cartasDOsJogador1);
                Array.Sort(cartasDOsJogador2);

                for (int i = 4; i >= 0; i--)
                {


                    if (cartasDOsJogador1[i] != cartasDOsJogador2[i])
                    {
                        Label4.Text = "" + cartasDOsJogador1[i];
                        Label5.Text = "" + cartasDOsJogador2[i];
                        break;

                    }


                };
            }


            // enviar para javascript
            Label1.Text = ParaJS;



        }

        public static int verificarResultado( int[] cartasDeAlgumJogador, String[] naipesDeAlgumjogador){

            int resultado = 0;

            int contRoyal = 0;
            int contStraightFl = 0;
            int contFullHouse = 0;
            int contFlush = 0;
            int contStraight = 0;
            int contThreeOfaKind = 0;
            int contOnePair = 0;
            
            for (int i = 0; i < 5; i++)
            {


                // Royal Flush jogador 1
                if ( cartasDeAlgumJogador[i] > 9)
                {
                    contRoyal++;
                }
                if (i < 4)
                {

                    if (naipesDeAlgumjogador[i] == naipesDeAlgumjogador[i + 1])
                    {
                        contRoyal++;
                    }
                }
                if (i == 4 && contRoyal == 9)
                {
                    resultado = 10;
                    
                    return resultado;

                }

                // StraightFlush jogador 1
               


                if (i < 4)
                {

                    if (naipesDeAlgumjogador[i] == naipesDeAlgumjogador[i + 1])
                    {
                        contStraightFl++;
                    }
                    if ( cartasDeAlgumJogador[i] <  cartasDeAlgumJogador[i + 1])
                    {
                        contStraightFl++;
                    }
                }

                if (i == 4 && contStraightFl == 8)
                {
                    resultado = 9;

                    return resultado;

                }


                // four of kind

                if (i == 4 && ( cartasDeAlgumJogador[0] ==  cartasDeAlgumJogador[1] &&  cartasDeAlgumJogador[2] ==  cartasDeAlgumJogador[1]
                    &&  cartasDeAlgumJogador[2] ==  cartasDeAlgumJogador[3]) || ( cartasDeAlgumJogador[1] ==  cartasDeAlgumJogador[2]
                     &&  cartasDeAlgumJogador[4] ==  cartasDeAlgumJogador[3] &&  cartasDeAlgumJogador[2] ==  cartasDeAlgumJogador[3]))
                {

                    resultado = 8;

                    return resultado;
                }

                //full house

                if (i < 4)
                {
                    if ( cartasDeAlgumJogador[i] ==  cartasDeAlgumJogador[i + 1])
                    {
                        contFullHouse++;
                    }
                }
                if (i == 4 && contFullHouse == 3)
                {

                    resultado = 7;

                    return resultado;
                }



                //flush
                if (i < 4)
                {

                    if (naipesDeAlgumjogador[i] == naipesDeAlgumjogador[i + 1])
                    {
                        contFlush++;
                    }
                }

                if (i == 4 && contFlush == 4)
                {

                    resultado = 6;

                    return resultado;
                }



                //Straight
                if (i < 4)
                {
                    if ( cartasDeAlgumJogador[i] + 1 ==  cartasDeAlgumJogador[i + 1])
                    {
                        contStraight++;
                    }
                }
                if (i == 4 && contStraight == 4)
                {
                    resultado = 5;

                    return resultado;

                }

                //Three of a kind
                if (i < 3)
                {
                    if ( cartasDeAlgumJogador[i] ==  cartasDeAlgumJogador[i + 1] &&  cartasDeAlgumJogador[i] ==  cartasDeAlgumJogador[i + 2])
                    {
                        contThreeOfaKind++;
                    }

                }
                if (i == 4 && contThreeOfaKind == 1)
                {
                    resultado = 4;

                    return resultado;

                }

                //two pair
                if (i == 4 && (( cartasDeAlgumJogador[0] ==  cartasDeAlgumJogador[1] &&  cartasDeAlgumJogador[2] ==  cartasDeAlgumJogador[3]) ||
                    ( cartasDeAlgumJogador[1] ==  cartasDeAlgumJogador[2] &&  cartasDeAlgumJogador[4] ==  cartasDeAlgumJogador[3]) ||
                    ( cartasDeAlgumJogador[0] ==  cartasDeAlgumJogador[1] &&  cartasDeAlgumJogador[3] ==  cartasDeAlgumJogador[4])))
                {
                    resultado = 3;

                    return resultado;


                }
                //one pair
                if (i < 4)
                {
                    if ( cartasDeAlgumJogador[i] ==  cartasDeAlgumJogador[i + 1])
                    {
                        contOnePair++;
                    }
                }
                if (i == 4 && contOnePair == 1)
                {
                    resultado = 2;

                    return resultado;
                }

                //High Card

                if (i == 4)
                {
                    resultado = 1;

                    return resultado;

                }

               
            }//Fim do for 

            return resultado;
        }
        

        public static Random numeroAleatorio()
        {
            Random r = new Random();
            for (int k = 0; k < 5255; k++)
            {
                r = new Random();
            }
            return r;
        }
    }

    

}
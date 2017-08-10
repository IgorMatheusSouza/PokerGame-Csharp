<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jogo.aspx.cs" Inherits="jogoDeCartas.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link type="text/css" rel="stylesheet" href="frameworks/bootstrap.min.css" />
    <script src="frameworks/jquery-3.2.1.min.js"></script>
    <title>Jogo de Poker</title>
<style>
#Background{
    
    width: 100%;
    height: auto;
    
    bottom: 0;
    right: 0;
    min-width: 100%;
    min-height: 100%;
    position:fixed;
    z-index: -1000;

    
    }

    .cartas {
        width: 120px;
        height: 180px;
        background-image: url("imgs/backcardRed.png");
        margin: 5px 5px 5px 5px;
        display: inline-block;
        background-size: cover;
    }
    #jogador1, #jogador2 {
    width:670px;
    margin:auto;
    display:block;
    }
    hr {
    margin:80px 0 80px 0;
    }
    .cartas img {
    border-radius:10px;
    }

    #receberdados , .imgCartas{
        display:none;
    }

    #jogador2 >.cartas {
    background-image: url("imgs/backcardBlue.png")
    }

    .myBtn {
       display:block;
       width:200px;
       margin:40px auto -40px auto ;
    
       font-size:20px;
    }

    .textoVencedor {
     display:none;
    margin-top:-20px;
    font-size:25px;
    
        
         }

    .text-white {
    color:white;
    }

    footer {
    margin-top:50px;
    }

    #logo-footer {
    margin:auto;
    display:block;
    }
</style>

    
</head>
<body  runat="server">

    <img id="Background" src="imgs/JingleBells_game_background.jpg" alt="backg"/>


    <div id="jogador1">
        <h2 class="text-center text-danger">Jogador 1</h2>
        <div class="cartas">
        <asp:Image runat="server" class="imgCartas"  Id="image1"/>
        </div>
        <div class="cartas">
        <asp:Image runat="server" class="imgCartas"  Id="image2" />
        </div>
        <div class="cartas">
        <asp:Image runat="server" class="imgCartas" Id="image3" />
         </div>
        <div class="cartas">
        <asp:Image runat="server" class="imgCartas" Id="image4" />
         </div>
        <div class="cartas">
        <asp:Image runat="server" class="imgCartas" Id="image5" /> 
          </div>

    </div>


    <div class="btn btn-success myBtn" onclick="definirVencedor()">Virar as cartas</div>

    <hr/>
    <div class="textoVencedor text-center">55</div>

    <div id="jogador2">

        <h2 class="text-center text-info">Jogador 2</h2>
        <div class="cartas">
        <asp:Image runat="server" Id="image6" class="imgCartas" />
        </div>
        <div class="cartas">
        <asp:Image runat="server" Id="image7" class="imgCartas" />
        </div>
        <div class="cartas">
        <asp:Image runat="server" Id="image8" class="imgCartas" />
         </div>
        <div class="cartas">
        <asp:Image runat="server" Id="image9" Class="imgCartas" />
         </div>
        <div class="cartas">
        <asp:Image runat="server" Id="image10" class="imgCartas"/>
          </div>

    </div>
    
   

    

    

    <div id="receberdados">    
            <asp:label ID="Label1" runat="server"  >Hi</asp:label>
            <asp:label ID="Label2" runat="server"  >jogador 1</asp:label>
            <asp:label ID="Label3" runat="server"  >Jogador 2</asp:label>
            <asp:Label ID="Label4" runat="server" ></asp:Label>
            <asp:Label ID="Label5" runat="server" ></asp:Label>

   </div>       

    
<footer>
<h4 class="text-center text-white">Developed by Igor Matheus de Souza for ASC Solutions</h4>
    <img src="imgs/logo.png" id="logo-footer"/>


</footer>

    

    <script type="text/javascript">

        //Pegar informações do codebehind
        var posicaoDasCartas = document.getElementById("Label1").innerHTML;
        
        posicaoDasCartas = posicaoDasCartas.split("~");
        var Jogador1cartas= document.getElementById("Label2").innerHTML;
        var Jogador2cartas= document.getElementById("Label3").innerHTML;


        //colocar todas as cartas na pagina
        var classeDasCartas = document.getElementsByClassName("imgCartas");
        
        
       
        for (var i = 0; i < 10; i++) {
            
            classeDasCartas[i].src = "imgs/" + posicaoDasCartas[i]+ ".png";
 
        }
       
        //clicar no botao
        function definirVencedor() {

            if ($(".myBtn").text() == "Jogar novamente") {
                location.reload();
                return;
            }


            var txt = $(".textoVencedor");

            $(".imgCartas").fadeIn(1200);

            $(".myBtn").text("Jogar novamente");



            var rankjogador =["",""];
            
            //ver qual foi o rank das cartas na mao dos jogadores

            for (var i = 0; i < 2; i++) {
                var jotual;
                if (i == 0){joAtual =parseInt( Jogador1cartas) };
                if (i == 1) { joAtual = parseInt(Jogador2cartas) };

                
                switch (joAtual) {
                    case 1:
                        rankjogador[i] ="High card";
                        break;
                    case 2:
                        rankjogador[i] ="One pair";
                        break;
                    case 3:
                        rankjogador[i] = "Two pair";
                        break;
                    case 4:
                        rankjogador[i] = "Three of a kind";
                        break;
                    case 5:
                        rankjogador[i] = "Straight";
                        break;
                    case 6:
                        rankjogador[i] = "Flush";
                        break;
                    case 7:
                        rankjogador[i] = "Full House";
                        break;
                    case 8:
                        rankjogador[i] = "Four of a Kind";
                        break;
                    case 9:
                        rankjogador[i] = "Straight Flush";
                        break;
                    case 10:
                        rankjogador[i] = "Royal Flush";
                        break;
                    default:
                        rankjogador[i] = "5555";
        
                        
                }

                
            }

            //definir o texto do ganhador
            if (Jogador1cartas > Jogador2cartas) {
                txt.text("Jogador 1 ganhou com um "+ rankjogador[0]+" X " +rankjogador[1]);
                txt.addClass("text-danger");
            
            }
            if (Jogador1cartas < Jogador2cartas) {
                txt.text("Jogador 2 ganhou com um " + rankjogador[1] + " X " + rankjogador[0]);
                txt.addClass("text-info");

            }
            if (Jogador1cartas == Jogador2cartas) {
                var desempatej1 = parseInt(document.getElementById("Label4").innerHTML);
                var desempatej2 = parseInt(document.getElementById("Label5").innerHTML);
                

                if (desempatej1 > desempatej2) {

                    txt.text("Impatou com um " + rankjogador[0] + " X " + rankjogador[1] + ", mas o Jogador 1 ganhou por ter a carta maior");
                    txt.addClass("text-danger");
                }
                else if (desempatej1 < desempatej2) {

                    txt.text("Impatou com um " + rankjogador[0] + " X " + rankjogador[1] + ", mas o Jogador 2 ganhou por ter a carta maior");
                    txt.addClass("text-info");
                }
                else {
                    txt.text("impatou com " + rankjogador[1] + " X " + rankjogador[0]);
                    txt.addClass("text-white");
                }

           }
        
            
            
            txt.fadeIn(2000);
        }

    </script>
</body>
</html>

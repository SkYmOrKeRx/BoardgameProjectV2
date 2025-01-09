

using System.Collections.Generic;

namespace BoardgameProjectV2.Modelo;

internal static class BoardgamesMetaData
{
    public static List<Boardgame> GetBgs()
    {
        return new List<Boardgame>
        {
            new Boardgame("Catan", "Jogo de estratégia e comércio.", 1995, true, 45.99f, 9),
            new Boardgame("Ticket to Ride", "Construção de rotas ferroviárias.", 2004, true, 39.99f, 8),
            new Boardgame("Pandemic", "Jogo cooperativo de controle de epidemias.", 2008, true, 42.50f, 7),
            new Boardgame("Carcassonne", "Construção de territórios medievais.", 2000, true, 0f, 6),
            new Boardgame("Terra Mystica", "Expansão de territórios e gerenciamento de recursos.", 2012, true, 59.99f, 10),
            new Boardgame("Azul", "Jogo de estratégia inspirado na arte portuguesa.", 2017, true, 29.99f, 8),
            new Boardgame("7 Wonders", "Desenvolvimento de civilizações e maravilhas.", 2010, true, 34.99f, 8),
            new Boardgame("Splendor", "Coleção de gemas e construção de rotas comerciais.", 2014, true, 32.99f, 7),
            new Boardgame("Dixit", "Jogo de narrativas criativas e adivinhações.", 2008, true, 29.95f, 6),
            new Boardgame("Gloomhaven", "Exploração de masmorras e narrativa cooperativa.", 2017, true, 139.99f, 10),
            new Boardgame("Scythe", "Jogo de estratégia ambientado em um mundo alternativo.", 2016, true, 64.99f, 9),
            new Boardgame("Dominion", "Construção de baralhos em um reino medieval.", 2008, true, 0f, 8),
            new Boardgame("Terraforming Mars", "Jogo de terraformação e gerenciamento de recursos.", 2016, true, 59.99f, 9),
            new Boardgame("Codenames", "Jogo de palavras e dedução.", 2015, true, 0f, 7),
            new Boardgame("Wingspan", "Coleção de aves e estratégia ecológica.", 2019, true, 49.99f, 9)
        };
    }
}

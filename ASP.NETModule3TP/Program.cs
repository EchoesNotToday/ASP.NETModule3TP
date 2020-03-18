using ASP.NETModule3TP.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NETModule3TP
{
    class Program
    {

        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }

        static void Main(string[] args)
        {
            InitialiserDatas();

            // Afficher la liste des prénoms des auteurs dont le nom commence par G
            var auteurNomG = ListeAuteurs.Where(a => a.Nom.StartsWith("G"));
            Console.WriteLine("liste des prénoms des auteurs dont le nom commence par G:");
            foreach(var auteur in auteurNomG)
            {
                Console.WriteLine(auteur.Prenom);
            }
            Console.WriteLine();

            // Afficher l'auteur ayant écrit le plus de livres
            var auteurPlusDeLivres = ListeLivres.GroupBy(l => l.Auteur).OrderByDescending(n => n.Count()).FirstOrDefault().Key;
            Console.WriteLine($"Auteur ayant écrit le plus de livre: {auteurPlusDeLivres.Prenom} {auteurPlusDeLivres.Nom}");
            Console.WriteLine();


            // Afficher le nombre moyen de page par livre  par auteur
            var livresParAuteur = ListeLivres.GroupBy(l => l.Auteur);
            Console.WriteLine("Nombre moyen de page par livre par auteur:");
            foreach (var livre in livresParAuteur)
            {
                Console.WriteLine($"Auteur: {livre.Key.Prenom} {livre.Key.Nom} Nombre de page moyen: {livre.Average(l => l.NbPages)}");
            }
            Console.WriteLine();

            // Afficher le titre du livre avec le plus de pages
            var livreLePlusGrand = ListeLivres.OrderByDescending(l => l.NbPages).FirstOrDefault();
            Console.WriteLine($"Livre avec le plus de page {livreLePlusGrand.Titre} avec {livreLePlusGrand.NbPages} pages");
            Console.WriteLine();

            // Afficher combien ont gagné les auteurs en moyenne
            var gainMoyen = ListeAuteurs.Average(a => a.Factures.Sum(f => f.Montant));
            Console.WriteLine($"Gain moyen : {gainMoyen}");
            Console.WriteLine();

            // Afficher les auteurs et la liste de leurs livres
            Console.WriteLine("Liste des livres par auteurs:");
            foreach (var livre in livresParAuteur)
            {
                Console.WriteLine();
                Console.WriteLine($"Auteur : {livre.Key.Prenom} {livre.Key.Nom}");
                foreach (var l in livre)
                {
                    Console.WriteLine(l.Titre);
                }
            }
            Console.WriteLine();

            // Afficher la liste de tous les livres par ordre alphabétique
            var ListeLivresAscTitre = ListeLivres.OrderBy(l => l.Titre);
            Console.WriteLine("Liste des livres par odre alphabétique");
            foreach (var livre in ListeLivresAscTitre)
            {
                Console.WriteLine(livre.Titre);
            }
            Console.WriteLine();


            // Afficher les livres dont le nombre de pages dépasse la moyenne
            var moyennePage = ListeLivres.Average(l => l.NbPages);
            var livresSupMoyenne = ListeLivres.Where(l => l.NbPages > moyennePage);
            Console.WriteLine("Affiche les livres dont le nombre de pages est supérieur à la moyenne.");
            foreach (var livre in livresSupMoyenne)
            {
                Console.WriteLine($"{livre.Titre} {livre.NbPages}");
            }

            Console.WriteLine();

            // Afficher l'auteur ayant fait le moins de livre
            var auteurMoinsDeLivres = ListeLivres.GroupBy(l => l.Auteur).OrderBy(n => n.Count()).FirstOrDefault().Key;
            var auteurMoinsDeLivresT = ListeAuteurs.OrderBy(a => ListeLivres.Count(l => l.Auteur == a)).FirstOrDefault();
            Console.WriteLine($"Vrai auteur avec 0 bouquin {auteurMoinsDeLivresT.Prenom} {auteurMoinsDeLivresT.Nom}");
            Console.WriteLine($"Auteur ayant écrit le moins de livre: {auteurMoinsDeLivres.Prenom} {auteurMoinsDeLivres.Nom}");
            Console.WriteLine();
            

            var p = ListeLivres.OrderBy(l => l.NbPages);
            Console.WriteLine($"Test pour exo");
            foreach (var p2 in p)
            {
                Console.WriteLine(p2.Titre);
            }


            Console.WriteLine();
            Console.WriteLine($"Test pour exo");
            var nombres = new[] { 4, 5, 8, 44, 34, 1323, 234, 1235, 665, 987 };
            Console.WriteLine("nombres.Any(i => i % 2 != 0)");
            Console.WriteLine(nombres.Any(i => i % 2 != 0));

            Console.WriteLine("nombres.All(i => i % 2 == 0)");
            Console.WriteLine(nombres.All(i => i % 2 == 0));

            Console.WriteLine("nombres.Any(i => i / 2 == 2)");
            Console.WriteLine(nombres.Any(i => i / 2 == 2));

            Console.WriteLine("nombres.All(i => i - 3 > 0)");
            Console.WriteLine(nombres.All(i => i - 3 > 0));


            Console.ReadKey();
        }
        
    }
}

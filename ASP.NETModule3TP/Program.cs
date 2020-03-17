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
            var auteurGPrenom = ListeAuteurs.Where(a => a.Nom.StartsWith("G")).Select(a => a.Prenom);
            Console.WriteLine("liste des prénoms des auteurs dont le nom commence par G:");
            foreach(var prenom in auteurGPrenom)
            {
                Console.WriteLine(prenom);
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
            Console.ReadKey();

        }
    }
}

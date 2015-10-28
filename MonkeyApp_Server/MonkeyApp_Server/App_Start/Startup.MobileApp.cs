using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using MonkeyAppServer.DataObjects;
using MonkeyAppServer.Models;
using Owin;

namespace MonkeyAppServer
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new monkeyapp5Initializer());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer(null);

            app.UseMobileAppAuthentication(config);
            app.UseWebApi(config);
        }
    }

    public class monkeyapp5Initializer : CreateDatabaseIfNotExists<monkeyapp5Context>
    {
        protected override void Seed(monkeyapp5Context context)
        {
            List<Monkey> monkeys = new List<Monkey>
            {
                new Monkey { Id = Guid.NewGuid().ToString(), Name = "Baboon", Location="Africa and Arabia", Population=1500, Image ="http://upload.wikimedia.org/wikipedia/commons/thumb/9/96/Portrait_Of_A_Baboon.jpg/314px-Portrait_Of_A_Baboon.jpg", Details="Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae." },
                new Monkey { Id = Guid.NewGuid().ToString(), Name = "Capuchin Monkey", Location="Central and South America", Population=18000, Image="http://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg", Details="The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus." },
                new Monkey { Id = Guid.NewGuid().ToString(), Name = "Blue Monkey", Location="Central and East Africa", Population=1900, Image="http://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg", Details="The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia." },
                new Monkey { Id = Guid.NewGuid().ToString(), Name = "Squirrel Monkey", Location="Central and South America", Population=3300, Image="http://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Saimiri_sciureus-1_Luc_Viatour.jpg/220px-Saimiri_sciureus-1_Luc_Viatour.jpg", Details="The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers." },
                new Monkey { Id = Guid.NewGuid().ToString(), Name = "Golden Lion Tamarin", Location="Brazil", Population=18600, Image="http://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Golden_lion_tamarin_portrait3.jpg/220px-Golden_lion_tamarin_portrait3.jpg", Details="The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae." },
                new Monkey { Id = Guid.NewGuid().ToString(), Name = "Howler Monkey", Location="South America", Population=10900, Image="http://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/Alouatta_guariba.jpg/200px-Alouatta_guariba.jpg", Details="Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae." },
                new Monkey { Id = Guid.NewGuid().ToString(), Name = "Japanese Macaque", Location="Japan", Population=7300, Image="http://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Macaca_fuscata_fuscata1.jpg/220px-Macaca_fuscata_fuscata1.jpg", Details="The Japanese macaque, is a terrestrial Old World monkey species native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each." },
                new Monkey { Id = Guid.NewGuid().ToString(), Name = "Mandrill", Location="Southern Cameroon, Gabon, Equatorial Guinea, and Congo", Population=0, Image="http://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Mandrill_at_san_francisco_zoo.jpg/220px-Mandrill_at_san_francisco_zoo.jpg", Details="The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Gabon, Equatorial Guinea, and Congo." },
                new Monkey { Id = Guid.NewGuid().ToString(), Name = "Proboscis Monkey", Location="Borneo", Population=9000, Image="http://upload.wikimedia.org/wikipedia/commons/thumb/e/e5/Proboscis_Monkey_in_Borneo.jpg/250px-Proboscis_Monkey_in_Borneo.jpg", Details="The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey that is endemic to the south-east Asian island of Borneo." },
                new Monkey { Id = Guid.NewGuid().ToString(), Name = "Sebastian", Location="Seattle", Population=1, Image="http://www.refractored.com/images/sebastian.jpg", Details="This little trouble maker lives in Seattle with James and loves traveling on adventures with James and tweeting @MotzMonkeys. He by far is an Android fanboy and is getting ready for the new Nexus 6P!" },
                new Monkey { Id = Guid.NewGuid().ToString(), Name = "Henry", Location="Phoenix", Population=1, Image="http://www.refractored.com/images/henry.jpg", Details="An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. His favorite platform is iOS by far and is excited for the new iPhone 6s!" },
                new Monkey { Id = Guid.NewGuid().ToString(), Name = "Emperor Tamarin", Location="Amazon Basin", Population=20000, Image="https://upload.wikimedia.org/wikipedia/commons/thumb/7/75/EmperorTamarin_CincinnatiZoo.jpg/282px-EmperorTamarin_CincinnatiZoo.jpg", Details="The Emperor tamarin is a small species of monkey found in the forests of South America. The Emperor tamarin was named because of it's elegant white moustache, which is thought to resemble that of German emperor Wilhelm II." },
                new Monkey { Id = Guid.NewGuid().ToString(), Name = "Red-handed Tamarin", Location="Africa", Population=21000, Image="https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Saguinus_midas_flk24863753.jpg/320px-Saguinus_midas_flk24863753.jpg", Details="The red-handed tamarin (Saguinus midas), also known as the golden-handed tamarin or Midas tamarin, is a New World monkey named for the contrasting reddish-orange hair on its feet and hands." },
            };

            foreach (Monkey monkey in monkeys)
            {
                context.Set<Monkey>().Add(monkey);
            }

            base.Seed(context);
        }
    }
}


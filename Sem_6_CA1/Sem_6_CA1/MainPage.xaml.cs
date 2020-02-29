using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Sem_6_CA1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<TV_Show> shows = new List<TV_Show>();
        TV_Show aos;
        TV_Show travelers;
        TV_Show killingEve;
        TV_Show nikitaShow;
        TV_Show orphanBlack;
        TV_Show b99;
        TV_Show you;
        TV_Show brba;
        TV_Show shadowhunters;
        TV_Show twelveMonkeys;

        public MainPage()
        {
            this.InitializeComponent();
            SetTVShowDetails();
            AddShowsToList();
            SetButtonToolTips();
        }

        public void SetButtonToolTips()
        {
            ToolTip toolTipAOS = new ToolTip();
            toolTipAOS.Content = shows[0].Title + " (" + shows[0].YearOfShow + ")" + "\n\n" + shows[0].Synopsis;
            ToolTipService.SetToolTip(BtnAOS, toolTipAOS);

            ToolTip toolTipTrav = new ToolTip();
            toolTipTrav.Content = shows[1].Title + " (" + shows[1].YearOfShow + ")" + "\n\n" + shows[1].Synopsis;
            ToolTipService.SetToolTip(BtnTravelers, toolTipTrav);

            ToolTip toolTipKE = new ToolTip();
            toolTipKE.Content = shows[2].Title + " (" + shows[2].YearOfShow + ")" + "\n\n" + shows[2].Synopsis;
            ToolTipService.SetToolTip(BtnKE, toolTipKE);

            ToolTip toolTipNik = new ToolTip();
            toolTipNik.Content = shows[3].Title + " (" + shows[3].YearOfShow + ")" + "\n\n" + shows[3].Synopsis;
            ToolTipService.SetToolTip(BtnNikita, toolTipNik);

            ToolTip toolTipOB = new ToolTip();
            toolTipOB.Content = shows[4].Title + " (" + shows[4].YearOfShow + ")" + "\n\n" + shows[4].Synopsis;
            ToolTipService.SetToolTip(BtnOB, toolTipOB);

            ToolTip toolTipB99 = new ToolTip();
            toolTipB99.Content = shows[5].Title + " (" + shows[5].YearOfShow + ")" + "\n\n" + shows[5].Synopsis;
            ToolTipService.SetToolTip(BtnB99, toolTipB99);

            ToolTip toolTipYou = new ToolTip();
            toolTipYou.Content = shows[6].Title + " (" + shows[6].YearOfShow + ")" + "\n\n" + shows[6].Synopsis;
            ToolTipService.SetToolTip(BtnYou, toolTipYou);

            ToolTip toolTipBrba = new ToolTip();
            toolTipBrba.Content = shows[7].Title + " (" + shows[7].YearOfShow + ")" + "\n\n" + shows[7].Synopsis;
            ToolTipService.SetToolTip(BtnBRBA, toolTipBrba);

            ToolTip toolTipSH = new ToolTip();
            toolTipSH.Content = shows[8].Title + " (" + shows[8].YearOfShow + ")" + "\n\n" + shows[8].Synopsis;
            ToolTipService.SetToolTip(BtnSH, toolTipSH);

            ToolTip toolTip12M = new ToolTip();
            toolTip12M.Content = shows[9].Title + " (" + shows[9].YearOfShow + ")" + "\n\n" + shows[9].Synopsis;
            ToolTipService.SetToolTip(Btn12M, toolTip12M);
        }

        public void AddShowsToList()
        {
            shows.Add(aos);
            shows.Add(travelers);
            shows.Add(killingEve);
            shows.Add(nikitaShow);
            shows.Add(orphanBlack);
            shows.Add(b99);
            shows.Add(you);
            shows.Add(brba);
            shows.Add(shadowhunters);
            shows.Add(twelveMonkeys);
        }

        public void SetTVShowDetails()
        {
            //AOS Cast Roles
            CastRole simmons = new CastRole("Jemma Simmons", "2013-2020");
            CastRole fitz = new CastRole("Leopold Fitz", "2013-2020");
            CastRole daisy = new CastRole("Daisy Johnson / Skye", "2013-2020");

            BitmapImage aOSImage = new BitmapImage();
            aOSImage.UriSource = new Uri("ms-appx:///Images/AOS.jpg");

            //AOS Cast Members
            CastMember elizabeth = new CastMember(new Name("Elizabeth",  "Henstridge"), new DateTime(1987, 09, 11), simmons,
                "Elizabeth Henstridge grew up in the northern city of Sheffield in England. Having " +
                "gained a first at The University Of Birmingham in Drama and Theatre Arts, Elizabeth " +
                "went on to train at the prestigious East 15 Acting School in London. ", 5,
                "https://www.imdb.com/name/nm4464857/?ref_=ttfc_fc_cl_t5");

            CastMember iain = new CastMember(new Name("Iain", "De Caestecker"), new DateTime(1987, 12, 29), fitz,
                "Iain De Caestecker has a twin sister and is one of four children; his parents are both medical doctors. " +
                "He went to Hillhead Primary School and successfully completed an HND in Acting and Performance at Langside College. " +
                "He played the lead in two high-profile BBC series -BAFTA - winning The Fades and Young James Herriot(both 2011).", 5,
                "https://www.imdb.com/name/nm0207691/?ref_=ttfc_fc_cl_t4");

            CastMember chloe = new CastMember(new Name("Chloe", "Bennet"), new DateTime(1992, 04, 18), daisy,
                "Chloe Bennet is an American actress and singer.She is best known for the ABC Agents of S.H.I.E.L.D. (2013). Bennet " +
                "was born Chloe Wang in Chicago, Illinois.Her father is Han Chinese and her mother is Caucasian American. ", 4,
                "https://www.imdb.com/name/nm4032297/?ref_=ttfc_fc_cl_t3");

            aos = new TV_Show("Agents of S.H.I.E.L.D", aOSImage, "2013", "Sci-Fi", "ABC", "Fridays @ 8pm", 
                "Phil Coulson of the Strategic Homeland Intervention, Enforcement and Logistics Division " +
                "assembles an elite covert team to find and deal with these threats wherever they are found. " +
                "With a world rapidly becoming more bizarre and dangerous than ever before as the supervillains arise, " +
                "these agents of S.H.I.E.L.D. are ready to take them on.");

            aos.AddCastMember(elizabeth);
            aos.AddCastMember(iain);
            aos.AddCastMember(chloe);

            //Travelers
            CastRole marcy = new CastRole("Marcy Warton", "2016-2018");
            CastRole philip = new CastRole("Philip Pearson", "2016-2018");
            CastRole carly = new CastRole("Carly Shannon", "2016-2018");

            BitmapImage travImage = new BitmapImage();
            travImage.UriSource = new Uri("ms-appx:///Images/trav.jpg");

            //Travelers Cast Members
            CastMember mackenzie = new CastMember(new Name("MackKenzie", "Porter"), new DateTime(1990, 01, 29), marcy,
                "Raised on a cattle and bison ranch in Southern Alberta, MacKenzie began studying piano, violin, and voice " +
                "at the young age of four. As a classically trained violinist, MacKenzie performed for many years as a " +
                "soloist and a chamber musician, performing with various symphonies. ", 4,
                "https://www.imdb.com/name/nm2311411/?ref_=tt_cl_t2");

            CastMember reilly = new CastMember(new Name("Reilly", "Dolman"), new DateTime(1988, 02, 29), philip,
                "Reilly Dolman is an actor, known for Travelers (2016), Supernatural (2005) and Percy Jackson & the " +
                "Lightning Thief (2010).", 5,
                "https://www.imdb.com/name/nm2835897/?ref_=tt_cl_t5");

            CastMember nesta = new CastMember(new Name("Nesta", "Cooper"), new DateTime(1993, 12, 11), carly,
                "Nesta Cooper was born on December 11, 1993 in Mississauga, Toronto, Ontario, Canada. She is " +
                "known for her work on The Edge of Seventeen(2016), #REALITYHIGH (2017) and Travelers (2016).", 5,
                "https://www.imdb.com/name/nm5050435/?ref_=tt_cl_t3");

            travelers = new TV_Show("Travelers", travImage, "2013", "Sci-Fi", "Netflix", "Ended",
                "Hundreds of years from now, surviving humans discover how to send consciousness back through time, " +
                "into people of the 21st century, while attempting to change the path of humanity.");

            travelers.AddCastMember(mackenzie);
            travelers.AddCastMember(reilly);
            travelers.AddCastMember(nesta);

            //Killing Eve
            CastRole eve = new CastRole("Eve Polastri", "2018-2020");
            CastRole villanelle = new CastRole("Villanelle", "2018-2020");
            CastRole bill = new CastRole("Bill Pargrave", "2018");

            BitmapImage keImage = new BitmapImage();
            travImage.UriSource = new Uri("ms-appx:///Images/ke.jpg");

            //Killing Eve Cast Members
            CastMember sandra = new CastMember(new Name("Sandra", "Oh"), new DateTime(1971, 07, 20), eve,
                "Sandra Oh was born to Korean parents in the Ottawa suburb of Nepean, Ontario, Canada. Her father, " +
                "Oh Junsu, a businessman, and her mother, Oh Young-Nam, a biochemist, were married in Seoul, Korea.", 4,
                "https://www.imdb.com/name/nm0644897/?ref_=ttfc_fc_cl_t1");

            CastMember jodie = new CastMember(new Name("Jodie", "Comer"), new DateTime(1993, 03, 11), villanelle,
                "Jodie Comer was born on March 11, 1993 in Liverpool, Merseyside, England.She is known for her work on " +
                "Killing Eve(2018), Star Wars: The Rise of Skywalker(2019) and Doctor Foster(2015).", 5,
                "https://www.imdb.com/name/nm3069650/?ref_=ttfc_fc_cl_t2");

            CastMember david = new CastMember(new Name("David", "Cooper"), new DateTime(1955, 09, 20), bill,
                "David Haig was born on September 20, 1955 in Aldershot, England as David Haig Collum Ward. He " +
                "is an actor and writer, known for My Boy Jack (2007), Two Weeks Notice (2002) and Florence Foster " +
                "Jenkins (2016). ", 3,
                "https://www.imdb.com/name/nm5050435/?ref_=tt_cl_t3");

            killingEve = new TV_Show("Killing Eve", keImage, "2018", "Thriller", "BBC", "Wednesdays @ 9pm",
                "After a series of events, the lives of a security operative and an assassin become inextricably linked.");

            travelers.AddCastMember(sandra);
            travelers.AddCastMember(jodie);
            travelers.AddCastMember(david);

            //Nikita
            CastRole nikita = new CastRole("Nikita", "2010-2013");
            CastRole birkhoff = new CastRole("Seymour Birkhoff", "2010-2013");
            CastRole alex = new CastRole("Lynsey Fonseca", "2010-2013");

            BitmapImage nikitaImage = new BitmapImage();
            travImage.UriSource = new Uri("ms-appx:///Images/nikita.jpg");

            //Nikita Cast Members
            CastMember maggie = new CastMember(new Name("Maggie", "Q"), new DateTime(1979, 05, 22), nikita,
                "Margaret Denise Quigley was born in Honolulu, Hawaii, to a father of Polish and Irish " +
                "descent (originally based in New York) and a Vietnamese mother. Her parents met during " +
                "the Vietnam War. ", 5,
                "https://www.imdb.com/name/nm0702572/?ref_=tt_cl_t1");

            CastMember aaron = new CastMember(new Name("Aaron", "Stanford"), new DateTime(1976, 12, 27), birkhoff,
                "An actor who consistently brings intensity and intelligence to his work, Aaron Stanford is poised " +
                "to become one of the foremost talents of his generation. Aaron received critical acclaim for his " +
                "feature film debut in _Tadpole_ opposite Sigourney Weaver and Bebe Neuwirth. ", 5,
                "https://www.imdb.com/name/nm0822155/?ref_=tt_cl_t4");

            CastMember lynsey = new CastMember(new Name("Lynsey", "Fonseca"), new DateTime(1987, 01, 07), alex,
                "Lyndsy Marie Fonseca was born in Oakland, California, and was raised first in Alameda and then " +
                "Moraga, California. Lyndsy competed in the International Modeling & Talent Association, where " +
                "she was recognized as the second runner-up for 'Young Miss Dancer of the Year' and was the " +
                "first runner-up for 'Miss Barbizon Young Miss Talent of the Year'.", 5,
                "https://www.imdb.com/name/nm0960912/?ref_=tt_cl_t3");

            nikitaShow = new TV_Show("Nikita", nikitaImage, "2010", "Action", "The CW", "Ended",
                "A rogue assassin returns to take down the secret organization that trained her.");

            nikitaShow.AddCastMember(maggie);
            nikitaShow.AddCastMember(aaron);
            nikitaShow.AddCastMember(lynsey);

            //Orphan Black
            CastRole various = new CastRole("Sarah Manning / Elizabeth Childs / Alison Hendrix / Cosima Niehaus / " +
                "Helena / Rachel Duncan / Tony Sawicki / Jennifer Fitzsimmons / Katja Obinger / " +
                "Pupok (Scorpion, voice) / Krystal Goderitch / Veera Suominen (M.K.) / Various", "2013-2017");

            BitmapImage orphanBlackImage = new BitmapImage();
            travImage.UriSource = new Uri("ms-appx:///Images/orphanBlack.jpg");

            //Orphan Black Cast Members
            CastMember tatiana = new CastMember(new Name("Tatiana", "Maslany"), new DateTime(1985, 09, 22), various,
                "Tatiana Gabrielle Maslany was born September 22, 1985 in Regina, Saskatchewan, to Renate, a " +
                "translator, and Dan, a woodworker.She graduated from Dr.Martin LeBoldus High school in 2003. She " +
                "is best known for her work on Orphan Black where she portrayed more than 15 characters.", 5,
                "https://www.imdb.com/name/nm1137209/?ref_=tt_ov_st_sm");


            orphanBlack = new TV_Show("Orphan Black", orphanBlackImage, "2013", "Thriller", "BBC America", "Ended",
                "A streetwise hustler is pulled into a compelling conspiracy after witnessing the suicide" +
                " of a girl who looks just like her.");

            orphanBlack.AddCastMember(tatiana);

            //Brooklyn Nine-Nine
            CastRole jake = new CastRole("Jake Peralta", "2013-");
            CastRole amy = new CastRole("Amy Santiago", "2013-");
            CastRole rosa = new CastRole("Rosa Diaz", "2013-");

            BitmapImage b99Image = new BitmapImage();
            travImage.UriSource = new Uri("ms-appx:///Images/b99.jpg");

            //Brooklyn Nine-Nine Cast Members
            CastMember andy = new CastMember(new Name("Andy", "Samberg"), new DateTime(1978, 08, 18), jake,
                "Andy Samberg was born in Berkeley, California, to Marjorie (Marrow), a teacher, and " +
                "Joe Samberg, a photographer. ", 2,
                "https://www.imdb.com/name/nm1676221/?ref_=tt_cl_t1");

             CastMember melissa = new CastMember(new Name("Melissa", "Fumero"), new DateTime(1982, 08, 19), amy,
            "Melissa Fumero was born on August 19, 1982 in Lyndhurst, New Jersey, USA as Melissa Gallo. She is an " +
            "actress, known for Brooklyn Nine-Nine (2013), I Hope They Serve Beer in Hell (2009) and One Life to " +
            "Live (1968).", 1,
            "https://www.imdb.com/name/nm0303073/?ref_=tt_cl_t4");

             CastMember stephanie = new CastMember(new Name("Stephanie", "Beatriz"), new DateTime(1982, 08, 19), amy,
            "Stephanie Beatriz was born as Stephanie Beatriz Bischoff Alvizuri. She is an actress, known for Short " +
            "Term 12 (2013), Brooklyn Nine-Nine (2013) and The Lego Movie 2: The Second Part (2019). She has been " +
            "married to Brad Hoss since October 6, 2018. ", 5,
            "https://www.imdb.com/name/nm3715867/?ref_=tt_cl_t2");

            b99 = new TV_Show("Brooklyn Nine-Nine", b99Image, "2013", "Comedy", "NBC", "Thursdays @ 7pm",
                "Jake Peralta, an immature, but talented N.Y.P.D. detective in Brooklyn's 99th Precinct, comes " +
                "into immediate conflict with his new commanding officer, the serious and stern Captain Ray Holt.");

            b99.AddCastMember(andy);
            b99.AddCastMember(melissa);
            b99.AddCastMember(stephanie);

            //You
            CastRole joe = new CastRole("Joe Goldberg", "2018-");
            CastRole love = new CastRole("Love Quinn", "2019-");
            CastRole forty = new CastRole("Forty Quinn", "2019");

            BitmapImage youImage = new BitmapImage();
            travImage.UriSource = new Uri("ms-appx:///Images/you.jpg");

            //You Cast Members
            CastMember penn = new CastMember(new Name("Penn", "Badgely"), new DateTime(1986, 11, 01), jake,
                "Penn Badgley was born in Baltimore, Maryland, to Lynne Murphy Badgley and Duff Badgley, who " +
                "worked as a newspaper reporter and carpenter. Badgley split his childhood years between " +
                "Richmond, Virginia. and Seattle, Washington. ", 5,
                "https://www.imdb.com/name/nm0046112/?ref_=tt_cl_t1");

            CastMember victoria = new CastMember(new Name("Victoria", "Pedretti"), new DateTime(1995, 03, 23), amy,
           "Victoria Pedretti is an American film and television actress, best known for her portrayal of Eleanor " +
           "'Nell' Crain in the Netflix television series The Haunting of Hill House, created and directed by " +
           "Mike Flanagan. ", 1,
           "https://www.imdb.com/name/nm6442992/?ref_=tt_cl_t3");

            CastMember james = new CastMember(new Name("James", "Scully"), new DateTime(1992, 04, 19), amy,
           "James Scully is an actor, known for Heathers (2018), You (2018) and Straight Up (2019).", 4,
           "https://www.imdb.com/name/nm8510480/?ref_=tt_cl_t8");

            you = new TV_Show("You", youImage, "2018", "Thriller", "Netflix", "Tuesdays @ 10pm",
                "A dangerously charming, intensely obsessive young man goes to extreme measures to insert " +
                "himself into the lives of those he is transfixed by.");

            you.AddCastMember(penn);
            you.AddCastMember(victoria);
            you.AddCastMember(james);

            //Breaking Bad
            CastRole jesse = new CastRole("Jesse Pinkman", "2008-2013");
            CastRole walt = new CastRole("Walter White", "2008-2013");
            CastRole saul = new CastRole("Saul Goodman", "2009-2013");

            BitmapImage brbaImage = new BitmapImage();
            travImage.UriSource = new Uri("ms-appx:///Images/brba.jpg");

            //Breaking Bad Cast Members
            CastMember aaronP = new CastMember(new Name("Aaron", "Paul"), new DateTime(1979, 08, 27), jesse,
                "Aaron Paul was born Aaron Paul Sturtevant in Emmett, Idaho, to Darla (Haynes) and Robert Sturtevant, " +
                "a retired Baptist minister. While growing up, Paul took part in church programs, and performed in plays. " +
                "He attended Centennial High School in Boise, Idaho. It was there, in eighth grade, that Aaron decided he " +
                "wanted to become an actor. ", 5,
                "https://www.imdb.com/name/nm0666739/?ref_=tt_cl_t3");

            CastMember bryan = new CastMember(new Name("Bryan", "Cranston"), new DateTime(1956, 03, 07), walt,
           "Bryan Lee Cranston was born on March 7, 1956 in Hollywood, California, to Audrey Peggy Sell, a radio actress, " +
           "and Joe Cranston, an actor and former amateur boxer. His maternal grandparents were German, and his father was of " +
           "Irish, German, and Austrian-Jewish ancestry. ", 5,
           "https://www.imdb.com/name/nm0186505/?ref_=tt_cl_t1");

            CastMember bobO = new CastMember(new Name("Bob", "Odenkirk"), new DateTime(1962, 10, 26), saul,
           "Robert John Odenkirk was born in Berwyn, Illinois, to Barbara (Baier) and Walter Odenkirk, who worked in " +
           "printing. His ancestry includes German and Irish. He grew up in Naperville, IL, the second of seven children. " +
           "He worked as a DJ for WIDB, his college radio station at Southern Illinois University Carbondale. ", 1,
           "https://www.imdb.com/name/nm0644022/?ref_=tt_cl_t7");

            brba = new TV_Show("Breaking Bad", brbaImage, "2008", "Thriller", "Freeform", "Ended",
                "A high school chemistry teacher diagnosed with inoperable lung cancer turns to manufacturing " +
                "and selling methamphetamine in order to secure his family's future.");

            brba.AddCastMember(aaronP);
            brba.AddCastMember(bryan);
            brba.AddCastMember(bobO);

            //Shadowhunters
            CastRole alec = new CastRole("Alec Lightwood", "2016-2019");
            CastRole clary = new CastRole("Jace Lightwood", "2016-2019");
            CastRole jace = new CastRole("Clary Fray", "2016-2019");

            BitmapImage shImage = new BitmapImage();
            travImage.UriSource = new Uri("ms-appx:///Images/sh.jpg");

            //Shadowhunters Cast Members
            CastMember matt = new CastMember(new Name("Matthew", "Daddario"), new DateTime(1987, 10, 01), alec,
                "Matthew Daddario was born and raised in New York to Richard and Christina Daddario, both lawyers. " +
                "He studied business at Indiana University in Bloomington. He graduated in 2010, after which he began " +
                "studying acting and started auditioning. ", 5,
                "https://www.imdb.com/name/nm4568989/");

            CastMember kat = new CastMember(new Name("Katherine", "McNamera"), new DateTime(1995, 11, 22), clary,
           "Katherine McNamara, named one of Vanity Fair's 'Breakout Bunch', is an accomplished actor, dancer, " +
           "singer/songwriter and was just awarded the 2018 People's Choice Award for Top Female Television Actress " +
           "for her leading role of 'Clary Fray' in the Freeform series, Shadowhunters", 1,
           "https://www.imdb.com/name/nm4123601/?ref_=tt_cl_t2");

            CastMember dom = new CastMember(new Name("Dominic", "Sherwood"), new DateTime(1990, 02, 06), jace,
           "Actor Dominic Anthony Sherwood was born in Kent, South East England. After studying Drama and Theater " +
           "Studies at schools in Maidstone, he left to work abroad starting in Kenya and moving for 6 months before " +
           "returning to London. ", 1,
           "https://www.imdb.com/name/nm8510480/?ref_=tt_cl_t8");

            shadowhunters = new TV_Show("Shadowhunters", shImage, "2016", "Fantasy", "Freeform", "Ended",
                "After her mother disappears, Clary must venture into the dark world of demon " +
                "hunting, and embrace her new role among the Shadowhunters.");

            shadowhunters.AddCastMember(matt);
            shadowhunters.AddCastMember(kat);
            shadowhunters.AddCastMember(dom);

            //12 Monkeys

            CastRole cole = new CastRole("James Cole", "2015-2018");
            CastRole cassie = new CastRole("Cassandra Railly", "2015-2018");
            CastRole jennifer = new CastRole("Jennifer Goines", "2015-2018");

            BitmapImage twelveM = new BitmapImage();
            twelveM.UriSource = new Uri("ms-appx:///Images/12Monkeys.jpg");

            //12 Monkeys Cast Members

            CastMember aaronS = new CastMember(new Name("Aaron", "Stanford"), new DateTime(1976, 12, 27), cole,
                "An actor who consistently brings intensity and intelligence to his work, Aaron Stanford is poised " +
                "to become one of the foremost talents of his generation. Aaron received critical acclaim for his " +
                "feature film debut in _Tadpole_ opposite Sigourney Weaver and Bebe Neuwirth. Since that breakout " +
                "performance, he has continued to tackle a variety of roles.", 5,
                "https://www.imdb.com/name/nm0822155/?ref_=nmbio_bio_nm");

            CastMember amanda = new CastMember(new Name("Amanda", "Schull"), new DateTime(1978, 8, 26), cassie,
           "Amanda Schull was born on August 26, 1978 in Honolulu, Hawaii, USA. She is an actress, known for 12 Monkeys (2015), Suits (2011) and Pretty Little Liars (2010).", 3,
           "https://www.imdb.com/name/nm0776040/?ref_=tt_ov_st_sm");

            CastMember emily = new CastMember(new Name("Emily", "Hampshire"), new DateTime(1981, 8, 29), jennifer,
           "Born and raised in Montreal, Emily Hampshire has made an indelible mark on the Canadian film and television industry " +
           "in a relatively short period of time. Her work has been recognized by the Canadian Academy of Cinema and Television with " +
           "3 Genie Award Nominations, a Gemini Award for her work on the small screen and was chosen by her peers in the Canadian " +
           "Actors Guild as a nominee for 'Outstanding Female Performance' at the ACTRA Awards.", 5,
           "https://www.imdb.com/name/nm0358922/?ref_=nmbio_bio_nm");

            twelveMonkeys = new TV_Show("12 Monkeys", twelveM, "2015", "Sci-Fi", "SyFy", "Ended",
                "Follows the journey of a time traveler from the post-apocalyptic future who appears in present day " +
                "on a mission to locate and eradicate the source of a deadly plague that will nearly destroy the human race.");

            twelveMonkeys.AddCastMember(aaronS);
            twelveMonkeys.AddCastMember(amanda);
            twelveMonkeys.AddCastMember(emily);           
        }
    }
}

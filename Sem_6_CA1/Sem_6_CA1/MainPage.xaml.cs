using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        List<TV_Show> showsSortedByYear = new List<TV_Show>();
        List<TV_Show> showsSortedByRating = new List<TV_Show>();
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
        List<TV_Show> showsToDisplay = new List<TV_Show>();

        public MainPage()
        {
            this.InitializeComponent();
            SetTVShowDetails();
            AddShowsToList();
            showsToDisplay = shows;
            showsGrid.ItemsSource = showsToDisplay;
            SortListByYear();
            SortListByRating();
        }

        private void rbSortByYear_Checked(object sender, RoutedEventArgs e)
        {
            SortListByYear();
            showsToDisplay = showsSortedByYear;
            showsGrid.ItemsSource = showsToDisplay;
        }

        private void rbSortByRating_Checked(object sender, RoutedEventArgs e)
        {
            SortListByRating();
            showsToDisplay = showsSortedByRating;
            showsGrid.ItemsSource = showsToDisplay;
        }

        public void SortListByYear()
        {
            showsSortedByYear = showsToDisplay.OrderByDescending(s => s.YearOfShow).ToList();
        }

        public void SortListByRating()
        {
            showsSortedByRating = showsToDisplay.OrderByDescending(s => s.ShowRating).ToList();
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

        private void OptionsMenu_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            //if (args.IsSettingsSelected == true)
            //{
            //    OptionsMenu_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            //}
            //else if (args.SelectedItemContainer != null)
            //{
            //    var navItemTag = args.SelectedItemContainer.Tag.ToString();
            //    OptionsMenu_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            //}
        }

        private void CbFilterByGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selected = cbFilterByGenre.SelectedValue.ToString();

            List<TV_Show> filteredList = new List<TV_Show>();
            if (selected.Equals("All"))
            {
                if(showsGrid != null)
                {
                    showsToDisplay = shows;
                    showsGrid.ItemsSource = showsToDisplay;
                }       
            }
            else if(!selected.Equals(""))
            {
                showsToDisplay = GetFilteredList(selected);
                showsGrid.ItemsSource = showsToDisplay;
            }        
        }

        private List<TV_Show> GetFilteredList(String selected)
        {
            List<TV_Show> filteredList = new List<TV_Show>();
            foreach(TV_Show show in shows)
            {
                if (show.Genre.Equals(selected))
                {
                    filteredList.Add(show);
                }
            }
            return filteredList;
        }

        private void ShowsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TV_Show selected = (TV_Show)showsGrid.SelectedItem;
            foreach (CastMember c in selected.GetCastMembers())
                Debug.WriteLine("Here: " + c);
            this.Frame.Navigate(typeof(ShowDetailsPage), selected);
        }

        public void SetTVShowDetails()
        {
            //AOS Cast Roles
            CastRole simmons = new CastRole("Jemma Simmons", "2013-2020", "Agent Jemma Anne Simmons is a genius biochemist " +
                "and one of the youngest and most prominent members of S.H.I.E.L.D. research division. Along with Leo Fitz, " +
                "Simmons was recruited to Coulson's Team and worked with them on all of their missions. While on the team, " +
                "Simmons became friends with Skye and Grant Ward. During the HYDRA Uprising, Simmons was an active participant " +
                "in hunting for John Garrett and the rest of the Centipede Project.");
            CastRole fitz = new CastRole("Leopold Fitz", "2013-2020", "Agent Leopold James 'Leo' Fitz is a S.H.I.E.L.D. " +
                "agent and scientist. A genius engineer, he is one of the youngest and most prominent members of S.H.I.E.L.D." +
                " Sci-Tech division, and inseparable from his research partner and friend (and later wife), Jemma Simmons. \n\n One of Iain's " +
                "most notable scenes in Agents of S.H.I.E.L.D is the following scene in which his character Fitz suffers a Scizophrenic break " +
                "due to a previous traumatic brain injury which left him with mental disabilities. This injury was further exacerbated by time he " +
                "spent living in another world living as a dictator.");
            CastRole daisy = new CastRole("Daisy Johnson / Skye", "2013-2020", "Agent Daisy 'Quake' Johnson, formerly known as Skye, " +
                "is an Inhuman, a genius-level hacker and a S.H.I.E.L.D. operative. She was born to Calvin Johnson and Jiaying, but was " +
                "taken away when her mother was seemingly killed by HYDRA. Growing up an orphan, she adopted the name Skye and worked for " +
                "the Rising Tide, putting her on S.H.I.E.L.D.'s radar. However, Phil Coulson recruited her into his team and appointed her " +
                "as a consultant where she became a valued agent during the hunt for the Clairvoyant. After the events of the HYDRA Uprising, " +
                "she joined the rest of her team in going off the grid.");

            //AOS Cast Members
            CastMember elizabeth = new CastMember(new Name("Elizabeth",  "Henstridge"), new DateTime(1987, 09, 11), simmons,
            "Elizabeth Henstridge grew up in the northern city of Sheffield in England. Having " +
            "gained a first at The University Of Birmingham in Drama and Theatre Arts, Elizabeth " +
            "went on to train at the prestigious East 15 Acting School in London. ", 5,
            "https://www.imdb.com/name/nm4464857/?ref_=ttfc_fc_cl_t5", "ms-appx:///Images/elizabeth.jpg");

            CastMember iain = new CastMember(new Name("Iain", "De Caestecker"), new DateTime(1987, 12, 29), fitz,
            "Iain De Caestecker has a twin sister and is one of four children; his parents are both medical doctors. " +
            "He went to Hillhead Primary School and successfully completed an HND in Acting and Performance at Langside College. " +
            "He played the lead in two high-profile BBC series -BAFTA - winning The Fades and Young James Herriot(both 2011).", 5,
            "https://www.imdb.com/name/nm0207691/?ref_=ttfc_fc_cl_t4", "ms-appx:///Images/iain.jpg");

            CastMember chloe = new CastMember(new Name("Chloe", "Bennet"), new DateTime(1992, 04, 18), daisy,
            "Chloe Bennet is an American actress and singer.She is best known for the ABC Agents of S.H.I.E.L.D. (2013). Bennet " +
            "was born Chloe Wang in Chicago, Illinois.Her father is Han Chinese and her mother is Caucasian American. ", 4,
            "https://www.imdb.com/name/nm4032297/?ref_=ttfc_fc_cl_t3", "ms-appx:///Images/chloe.jpg");

            List<CastMember> castMembersAOS = new List<CastMember>();

            castMembersAOS.Add(iain);
            castMembersAOS.Add(elizabeth);
            castMembersAOS.Add(chloe);

            aos = new TV_Show("Agents of S.H.I.E.L.D", "ms-appx:///Images/AOS.jpg", "2013", "Sci-Fi", "ABC", "Fridays @ 8pm", 
            "Phil Coulson of the Strategic Homeland Intervention, Enforcement and Logistics Division " +
            "assembles an elite covert team to find and deal with these threats wherever they are found. " +
            "With a world rapidly becoming more bizarre and dangerous than ever before as the supervillains arise, " +
            "these agents of S.H.I.E.L.D. are ready to take them on.", 5, "https://www.youtube.com/watch?v=Uqv6hlXKU4k", castMembersAOS);

            foreach (CastMember c in aos.GetCastMembers())
                Debug.WriteLine(c);

            //Travelers
            CastRole marcy = new CastRole("Marcy Warton", "2016-2018", "Marcy Warton (Traveler 3569), played by starring cast member " +
                "MacKenzie Porter, is the medic for the show's core team. Her host body is that of a mentally disabled woman who works as a " +
                "cleaning girl in a library. The fact that she was mentally disabled was unknown to The Director and others in the " +
                "future due to fake social media profiles created as an exercise with her social worker David Mailer to help teach her " +
                "about social media. The fake profile stated that she was a librarian and that David was a reporter doing research for a " +
                "newspaper story.");
            CastRole philip = new CastRole("Philip Pearson", "2016-2018", "Philip Pearson (Traveler 3326), played by starring cast member " +
                "Reilly Dolman, is the historian of the show's core Traveler team. His host body is a heroin-addicted college student, though " +
                "The Director and those in the future were unaware of his addiction due to his parent's statement that he had died after his " +
                "first use, most likely because they were in denial.");
            CastRole carly = new CastRole("Carly Shannon", "2016-2018", "Carly Shannon (Traveler 3465), played by starring cast member Nesta " +
                "Cooper, is a member of the show's core Traveler team and the team's Tactician. The host body is a stay at home mother in an " +
                "abusive relationship with the father of her baby, Police Officer Jeff Conniker. The Traveler consciousness, Traveler 3465, was " +
                "formerly in a relationship with fellow Traveler team member Grant MacLaren.");

            //Travelers Cast Members
            CastMember mackenzie = new CastMember(new Name("MackKenzie", "Porter"), new DateTime(1990, 01, 29), marcy,
                "Raised on a cattle and bison ranch in Southern Alberta, MacKenzie began studying piano, violin, and voice " +
                "at the young age of four. As a classically trained violinist, MacKenzie performed for many years as a " +
                "soloist and a chamber musician, performing with various symphonies. ", 4,
                "https://www.imdb.com/name/nm2311411/?ref_=tt_cl_t2", "ms-appx:///Images/mackenzie.jpg");

            CastMember reilly = new CastMember(new Name("Reilly", "Dolman"), new DateTime(1988, 02, 29), philip,
                "Reilly Dolman is an actor, known for Travelers (2016), Supernatural (2005) and Percy Jackson & the " +
                "Lightning Thief (2010).", 5,
                "https://www.imdb.com/name/nm2835897/?ref_=tt_cl_t5", "ms-appx:///Images/reilly.jpg");

            CastMember nesta = new CastMember(new Name("Nesta", "Cooper"), new DateTime(1993, 12, 11), carly,
                "Nesta Cooper was born on December 11, 1993 in Mississauga, Toronto, Ontario, Canada. She is " +
                "known for her work on The Edge of Seventeen(2016), #REALITYHIGH (2017) and Travelers (2016).", 5,
                "https://www.imdb.com/name/nm5050435/?ref_=tt_cl_t3", "ms-appx:///Images/nesta.jpg");

                List<CastMember> castMembersTrav = new List<CastMember>();

                castMembersTrav.Add(mackenzie);
                castMembersTrav.Add(reilly);
                castMembersTrav.Add(nesta);

                travelers = new TV_Show("Travelers", "ms-appx:///Images/trav.jpg", "2013", "Sci-Fi", "Netflix", "Ended",
                "Hundreds of years from now, surviving humans discover how to send consciousness back through time, " +
                "into people of the 21st century, while attempting to change the path of humanity.", 5, "https://www.youtube.com/watch?v=99LZwZmSoNo", castMembersTrav);

            //Killing Eve
            CastRole eve = new CastRole("Eve Polastri", "2018-2020", "Eve Polastri is one of the main protagonists in the BBC series Killing Eve. " +
                "She is an MI5 security operative who soon becomes involved in a cat-and-mouse game with a hired assassin Villanelle. The two women " +
                "becoming mutually obsessed, sharing what has been called a 'crackling chemistry... between bitter enemies and would-be lovers'. " +
                "Agent Polastri tracks the 'utterly unforgivable' assassin Villanelle across Europe, not as hero and villain but as 'two broken " +
                "women whose flaws bind them together in a twisted pas de deux'.");
            CastRole villanelle = new CastRole("Villanelle", "2018-2020", "Oksana Anatoljevna Astankova, better known as Villanelle, is a " +
                "hired assassin who soon becomes involved in a cat-and-mouse game with MI5 security operative Eve Polastri. The two women becoming " +
                "mutually obsessed, sharing what has been called a 'crackling chemistry... between bitter enemies and would-be lovers'. Agent Polastri " +
                "tracks the 'utterly unforgivable' assassin Villanelle across Europe, not as hero and villain but as 'two broken women whose flaws bind " +
                "them together in a twisted pas de deux'.");
            CastRole bill = new CastRole("Bill Pargrave", "2018", "Bill Pargrave is is Head of Security Section at MI5. Bill is weary. His independently - " +
                "wealthy wife, Keiko, and their newborn daughter have run him into the ground.He never sleeps and he sees work as a haven from home. He doesn’t " +
                "want trouble or excitement or controversy at work – he just wants life to be quiet. He ducked out of being the maverick field agent years ago. " +
                "But it flickers…He and Eve have worked together for over ten years – they have a great relationship. Bill humors Eve’s conspiracies, teases her " +
                "and also dismisses them. She has been right once or twice, but when she is, there is normally a whole load of bureaucratic red tape bullshit to " +
                "have to sort through that, these days, he’d rather not have to deal with. He is solid, but tired. When Eve proposes he join her in a secret assassin " +
                "tracking unit with MI6, he discovers he may have some life left in him yet.");

            //Killing Eve Cast Members
            CastMember sandra = new CastMember(new Name("Sandra", "Oh"), new DateTime(1971, 07, 20), eve,
                "Sandra Oh was born to Korean parents in the Ottawa suburb of Nepean, Ontario, Canada. Her father, " +
                "Oh Junsu, a businessman, and her mother, Oh Young-Nam, a biochemist, were married in Seoul, Korea.", 4,
                "https://www.imdb.com/name/nm0644897/?ref_=ttfc_fc_cl_t1", "ms-appx:///Images/sandra.jpg");

            CastMember jodie = new CastMember(new Name("Jodie", "Comer"), new DateTime(1993, 03, 11), villanelle,
                "Jodie Comer was born on March 11, 1993 in Liverpool, Merseyside, England.She is known for her work on " +
                "Killing Eve(2018), Star Wars: The Rise of Skywalker(2019) and Doctor Foster(2015).", 5,
                "https://www.imdb.com/name/nm3069650/?ref_=ttfc_fc_cl_t2", "ms-appx:///Images/jodie.jpg");

            CastMember david = new CastMember(new Name("David", "Haig"), new DateTime(1955, 09, 20), bill,
                "David Haig was born on September 20, 1955 in Aldershot, England as David Haig Collum Ward. He " +
                "is an actor and writer, known for My Boy Jack (2007), Two Weeks Notice (2002) and Florence Foster " +
                "Jenkins (2016). ", 3,
                "https://www.imdb.com/name/nm5050435/?ref_=tt_cl_t3", "ms-appx:///Images/david.jpg");

            List<CastMember> castMembersKE = new List<CastMember>();

            castMembersKE.Add(sandra);
            castMembersKE.Add(jodie);
            castMembersKE.Add(david);

            killingEve = new TV_Show("Killing Eve", "ms-appx:///Images/ke.jpg", "2018", "Thriller", "BBC", "Wednesdays @ 9pm",
            "After a series of events, the lives of a security operative and an assassin become inextricably linked.", 4, 
            "https://www.youtube.com/watch?v=Kk0PyD-XNZA", castMembersKE);

            //Nikita
            CastRole nikita = new CastRole("Nikita", "2010-2013", "Nikita Mears is a covert operations operative trained by the secret government " +
                "organization known as Division, she was recruited after escaping her abusive foster father, becoming a drug addict and living on the " +
                "streets - and was sent to death row after killing a police officer, upon which her death was faked. As a Division field agent, " +
                "Nikita fell in love with the civilian Daniel Monroe (who believed she was an airline consultant). After bugging his home, Division " +
                "ordered his death so that Nikita would not be distracted by emotional entanglements. She escaped the organization shortly thereafter, " +
                "on the run as they tried to hunt her down and eliminate her.");
            CastRole birkhoff = new CastRole("Seymour Birkhoff", "2010-2013", "Seymour Birkhoff (born Lionel Peller) is the tech man of Team " +
                "Nikita along with Sonya. He's also the former head of IT at Division. He's been at Division under both Percy and Ryan's command. Seymour " +
                "Birkhoff was born as Lionel Peller, a son of Ronald Peller (a computer engineer), and Rosemary. Rosemary had already given birth to a daughter, " +
                "Lily, and a son, Lyle. Lionel was considered an accident. After he successfully turned off the lights in the street using father's computer he " +
                "began to hang out with hackers. His father thought that he could set him straight if he sent him to the military school. Once Lionel had found " +
                "out about this, he decided to fake his death and change his name to Seymour Birkhoff. Before Seymour was recruited by Division, he was a college student. " +
                "During his time at college his cyber criminal handle was 'Shadow Walker'.");
            CastRole alex = new CastRole("Alexandra 'Alex' Udinov", "2010-2013", "Alex is the daughter of the late Russian oligarch " +
                "Nikolai Udinov and his wife who were murdered when Alex was a child. Nikolai owned the billion-dollar company Zetrov, " +
                "which Alex was the sole heir of. She was saved by Nikita as she watched the rest of her family perish. Nikita was powerless " +
                "to save Alex from anything else as she had to return to Division, and she gave Alex to one of Nikolai's associates. As a result, " +
                "Alex was sold into sex slavery at very young age by her father's former associate, since he was afraid of retribution for hiding her.");

            //Nikita Cast Members
            CastMember maggie = new CastMember(new Name("Maggie", "Q"), new DateTime(1979, 05, 22), nikita,
                "Margaret Denise Quigley was born in Honolulu, Hawaii, to a father of Polish and Irish " +
                "descent (originally based in New York) and a Vietnamese mother. Her parents met during " +
                "the Vietnam War. ", 5,
                "https://www.imdb.com/name/nm0702572/?ref_=tt_cl_t1", "ms-appx:///Images/maggie.jpg");

            CastMember aaron = new CastMember(new Name("Aaron", "Stanford"), new DateTime(1976, 12, 27), birkhoff,
                "An actor who consistently brings intensity and intelligence to his work, Aaron Stanford is poised " +
                "to become one of the foremost talents of his generation. Aaron received critical acclaim for his " +
                "feature film debut in _Tadpole_ opposite Sigourney Weaver and Bebe Neuwirth. ", 5,
                "https://www.imdb.com/name/nm0822155/?ref_=tt_cl_t4", "ms-appx:///Images/aaron2.jpg");

            CastMember lynsey = new CastMember(new Name("Lynsey", "Fonseca"), new DateTime(1987, 01, 07), alex,
                "Lyndsy Marie Fonseca was born in Oakland, California, and was raised first in Alameda and then " +
                "Moraga, California. Lyndsy competed in the International Modeling & Talent Association, where " +
                "she was recognized as the second runner-up for 'Young Miss Dancer of the Year' and was the " +
                "first runner-up for 'Miss Barbizon Young Miss Talent of the Year'.", 5,
                "https://www.imdb.com/name/nm0960912/?ref_=tt_cl_t3", "ms-appx:///Images/lynsey.jpg");

            List<CastMember> castMembersNikita = new List<CastMember>();

            castMembersNikita.Add(maggie);
            castMembersNikita.Add(aaron);
            castMembersNikita.Add(lynsey);

            nikitaShow = new TV_Show("Nikita", "ms-appx:///Images/nikita.jpg", "2010", "Action", "The CW", "Ended",
            "A rogue assassin returns to take down the secret organization that trained her.", 5, "https://www.youtube.com/watch?v=rqE1GKzmC6M", castMembersNikita);

            //Orphan Black
            CastRole various = new CastRole("Sarah Manning and many more", "2013-2017", "Tatiana Maslany rose to fame for her starring role in Orphan Black where she " +
                "plays 15+ clones with completely different personalities and quirks. Her main roles on the series include Sarah Manning - a streetwise con artist, Beth Childs - " +
                "a police officer, Cosima Niehaus - a scientist, Allison Hendrix - a suburban housewife and Helena - a psychotic killer. She appears in various other roles throughout " +
                "the series. ");

            //Orphan Black Cast Members
            CastMember tatiana = new CastMember(new Name("Tatiana", "Maslany"), new DateTime(1985, 09, 22), various,
                "Tatiana Gabrielle Maslany was born September 22, 1985 in Regina, Saskatchewan, to Renate, a " +
                "translator, and Dan, a woodworker.She graduated from Dr.Martin LeBoldus High school in 2003. She " +
                "is best known for her work on Orphan Black where she portrayed more than 15 characters.", 5,
                "https://www.imdb.com/name/nm1137209/?ref_=tt_ov_st_sm", "ms-appx:///Images/tatiana.jpg");

            List<CastMember> castMembersOB = new List<CastMember>();

            castMembersOB.Add(tatiana);

            orphanBlack = new TV_Show("Orphan Black", "ms-appx:///Images/orphanBlack.jpg", "2013", "Thriller", "BBC America", "Ended",
            "A streetwise hustler is pulled into a compelling conspiracy after witnessing the suicide" +
            " of a girl who looks just like her.", 3, "https://www.youtube.com/watch?v=do_BCA-vR9E", castMembersOB);

            //Brooklyn Nine-Nine
            CastRole jake = new CastRole("Jake Peralta", "2013-", "Detective Jacob 'Jake' Peralta is the main protagonist of the show. " +
                "He is a cocky, arrogant and immature but talented NYPD detective stationed in Brooklyn's 99th Precinct. Peralta is a cop that has " +
                "never had to work that hard or follow the rules too closely. Perhaps because he has the best arrest record among his colleagues, he's " +
                "been enabled - if not indulged - throughout his entire career.");
            CastRole amy = new CastRole("Amy Santiago", "2013-", "Sergeant Amy Santiago is a main character of the show. She is a sergeant and a former " +
                "detective at the 99th precinct of the NYPD. Always eager to impress, Amy is looking for a mentor to help her achieve her dream of being " +
                "the youngest person to be promoted to captain.");
            CastRole rosa = new CastRole("Rosa Diaz", "2013-", "Detective Rosalita 'Rosa' Diaz is a main character of the show. She is considered " +
                "'the tough guy' and the 'badass' in the Precinct. Rosa is scary, smart, secretive, and difficult to read. Most of the members of " +
                "the precinct are frightened and a little disturbed by her. Rosa takes pride in the fact that no one knows much about her. Jake only " +
                "knows three facts about her, one of which is that she won't let people crash at her place, despite the fact that Rosa refers to him as " +
                "her 'closest friend'.");

            //Brooklyn Nine-Nine Cast Members
            CastMember andy = new CastMember(new Name("Andy", "Samberg"), new DateTime(1978, 08, 18), jake,
                "Andy Samberg was born in Berkeley, California, to Marjorie (Marrow), a teacher, and " +
                "Joe Samberg, a photographer. ", 2,
                "https://www.imdb.com/name/nm1676221/?ref_=tt_cl_t1", "ms-appx:///Images/andy.jpg");

                CastMember melissa = new CastMember(new Name("Melissa", "Fumero"), new DateTime(1982, 08, 19), amy,
            "Melissa Fumero was born on August 19, 1982 in Lyndhurst, New Jersey, USA as Melissa Gallo. She is an " +
            "actress, known for Brooklyn Nine-Nine (2013), I Hope They Serve Beer in Hell (2009) and One Life to " +
            "Live (1968).", 1,
            "https://www.imdb.com/name/nm0303073/?ref_=tt_cl_t4", "ms-appx:///Images/melissa.jpg");

                CastMember stephanie = new CastMember(new Name("Stephanie", "Beatriz"), new DateTime(1982, 08, 19), amy,
            "Stephanie Beatriz was born as Stephanie Beatriz Bischoff Alvizuri. She is an actress, known for Short " +
            "Term 12 (2013), Brooklyn Nine-Nine (2013) and The Lego Movie 2: The Second Part (2019). She has been " +
            "married to Brad Hoss since October 6, 2018. ", 5,
            "https://www.imdb.com/name/nm3715867/?ref_=tt_cl_t2", "ms-appx:///Images/stephanie.jpg");


            List<CastMember> castMembersB99 = new List<CastMember>();

            castMembersB99.Add(andy);
            castMembersB99.Add(melissa);
            castMembersB99.Add(stephanie);

            b99 = new TV_Show("Brooklyn Nine-Nine", "ms-appx:///Images/b99.jpg", "2013", "Comedy", "NBC", "Thursdays @ 7pm",
            "Jake Peralta, an immature, but talented N.Y.P.D. detective in Brooklyn's 99th Precinct, comes " +
            "into immediate conflict with his new commanding officer, the serious and stern Captain Ray Holt.", 5, 
            "https://www.youtube.com/watch?v=sEOuJ4z5aTc", castMembersB99);

            //You
            CastRole joe = new CastRole("Joe Goldberg", "2018-", "Joe is a loner bookstore manager who becomes infatuated with " +
                "a woman named Guinevere Beck and begins to stalk her in a variety of ways to find out everything about her and " +
                "make her fall in love with him. However, his obsession soon becomes out of control when he starts trying to control " +
                "every aspect of her life.");
            CastRole love = new CastRole("Love Quinn", "2019-", "Love is an 'artistic' aspiring chef in LA working as a produce manager " +
                "in a high-end grocery store, and she's not interested in social media or branding and much more into leading an interesting " +
                "life. She is fiercely independent. Love is in grief when she meets Joe, and can sense he too has known life - changing loss.");
            CastRole forty = new CastRole("Forty Quinn", "2019", "Forty Quinn is a main character in the television series You. He's confident, " +
                "opinionated, and privileged, a charming bully or a razor-sharp bully. He's working through a 12-step program, relying on his sister " +
                "for support and attention.");

            //You Cast Members
            CastMember penn = new CastMember(new Name("Penn", "Badgely"), new DateTime(1986, 11, 01), joe,
                "Penn Badgley was born in Baltimore, Maryland, to Lynne Murphy Badgley and Duff Badgley, who " +
                "worked as a newspaper reporter and carpenter. Badgley split his childhood years between " +
                "Richmond, Virginia. and Seattle, Washington. ", 5,
                "https://www.imdb.com/name/nm0046112/?ref_=tt_cl_t1", "ms-appx:///Images/penn.jpg");

            CastMember victoria = new CastMember(new Name("Victoria", "Pedretti"), new DateTime(1995, 03, 23), love,
            "Victoria Pedretti is an American film and television actress, best known for her portrayal of Eleanor " +
            "'Nell' Crain in the Netflix television series The Haunting of Hill House, created and directed by " +
            "Mike Flanagan. ", 1,
            "https://www.imdb.com/name/nm6442992/?ref_=tt_cl_t3", "ms-appx:///Images/victoria.jpg");

            CastMember james = new CastMember(new Name("James", "Scully"), new DateTime(1992, 04, 19), forty,
            "James Scully is an actor, known for Heathers (2018), You (2018) and Straight Up (2019).", 4,
            "https://www.imdb.com/name/nm8510480/?ref_=tt_cl_t8", "ms-appx:///Images/james.jpg");

            List<CastMember> castMembersYou = new List<CastMember>();

            castMembersYou.Add(penn);
            castMembersYou.Add(victoria);
            castMembersYou.Add(james);

            you = new TV_Show("You", "ms-appx:///Images/you.jpg", "2018", "Thriller", "Netflix", "Tuesdays @ 10pm",
            "A dangerously charming, intensely obsessive young man goes to extreme measures to insert " +
            "himself into the lives of those he is transfixed by.", 5, "https://www.youtube.com/watch?v=srx7fSBwvF4", castMembersYou);

            //Breaking Bad
            CastRole jesse = new CastRole("Jesse Pinkman", "2008-2013", "Jesse Bruce Pinkman is the deuteragonist of Breaking Bad and " +
                "the main protagonist of El Camino. He is the former partner of Walter White in the methamphetamine drug trade. " +
                "Jesse was a small-time methamphetamine user, manufacturer, and dealer. He was also an inattentive student in Walter " +
                "White's chemistry class, leading to his dropping out. In his mid-20s, Jesse became Walt's business partner in the meth trade. " +
                "Before his partnership with Walt, he, operating under the pseudonym 'Cap'n Cook', added a little Chili powder to make his " +
                "methamphetamine stand out in the market.");
            CastRole walt = new CastRole("Walter White", "2008-2013", "Walter Hartwell 'Walt' White Sr., also known by his clandestine " +
                "pseudonym 'Heisenberg', is the main protagonist of Breaking Bad. He was a chemist and a former chemistry teacher in " +
                "Albuquerque, New Mexico, who, after being diagnosed with Stage 3A inoperable lung cancer, started manufacturing crystal " +
                "methamphetamine to both pay for his treatments and provide for his family in the event of his passing. He is the central " +
                "character of the series, and is portrayed as a protagonist, antagonist and antihero. As the series progresses, Walter " +
                "gradually becomes darker and takes on a more villainous role.");
            CastRole saul = new CastRole("Saul Goodman", "2009-2013", "James Morgan 'Jimmy' McGill, better known by his professional alias " +
                "Saul Goodman or Jimmy 'Saul Goodman' McGill ('Magic Man', is the former principal attorney of Saul Goodman & Associates. " +
                "He operated out of a cheap strip mall office and ran over-the-top late night TV commercials advising potential clients to '" +
                "Better Call Saul' when in trouble with the law. While his ads seemed tacky and cheap, Saul was an effective lawyer, using " +
                "illegal tactics and dirty schemes to get his clients released or acquitted.");

            //Breaking Bad Cast Members
            CastMember aaronP = new CastMember(new Name("Aaron", "Paul"), new DateTime(1979, 08, 27), jesse,
                "Aaron Paul was born Aaron Paul Sturtevant in Emmett, Idaho, to Darla (Haynes) and Robert Sturtevant, " +
                "a retired Baptist minister. While growing up, Paul took part in church programs, and performed in plays. " +
                "He attended Centennial High School in Boise, Idaho. It was there, in eighth grade, that Aaron decided he " +
                "wanted to become an actor. ", 5,
                "https://www.imdb.com/name/nm0666739/?ref_=tt_cl_t3", "ms-appx:///Images/aaron3.jpg");

            CastMember bryan = new CastMember(new Name("Bryan", "Cranston"), new DateTime(1956, 03, 07), walt,
            "Bryan Lee Cranston was born on March 7, 1956 in Hollywood, California, to Audrey Peggy Sell, a radio actress, " +
            "and Joe Cranston, an actor and former amateur boxer. His maternal grandparents were German, and his father was of " +
            "Irish, German, and Austrian-Jewish ancestry. ", 5,
            "https://www.imdb.com/name/nm0186505/?ref_=tt_cl_t1", "ms-appx:///Images/bryan.jpg");

            CastMember bobO = new CastMember(new Name("Bob", "Odenkirk"), new DateTime(1962, 10, 26), saul,
            "Robert John Odenkirk was born in Berwyn, Illinois, to Barbara (Baier) and Walter Odenkirk, who worked in " +
            "printing. His ancestry includes German and Irish. He grew up in Naperville, IL, the second of seven children. " +
            "He worked as a DJ for WIDB, his college radio station at Southern Illinois University Carbondale. ", 1,
            "https://www.imdb.com/name/nm0644022/?ref_=tt_cl_t7", "ms-appx:///Images/bob.jpg");

            List<CastMember> castMembersBrba = new List<CastMember>();

            castMembersBrba.Add(aaronP);
            castMembersBrba.Add(bryan);
            castMembersBrba.Add(bobO);

            brba = new TV_Show("Breaking Bad", "ms-appx:///Images/brba.jpg", "2008", "Thriller", "AMC", "Ended",
            "A high school chemistry teacher diagnosed with inoperable lung cancer turns to manufacturing " +
            "and selling methamphetamine in order to secure his family's future.", 5, "https://www.youtube.com/watch?v=Pev38s3xPgM", castMembersBrba);

            //Shadowhunters
            CastRole alec = new CastRole("Alec Lightwood", "2016-2019", "Alexander 'Alec' Lightwood-Bane is the brother of Isabelle and Max Lightwood, " +
                "the parabatai of Jace Herondale, and the husband of the High Warlock of Alicante, Magnus Bane. Alec is a responsible leader who cares " +
                "for the well-being of his people and is the current Inquisitor of the Clave.");
            CastRole clary = new CastRole("Jace Lightwood", "2016-2019", "Clarissa 'Clary' Fairchild, also known as Clary Fray, is a " +
                "Shadowhunter who was raised among mundanes, unaware of her true heritage. Clary's simple and content life was disrupted " +
                "when her mother was kidnapped, forcing her into action. Led on a journey of self-discovery in the dangerous and magical " +
                "Shadow World, the secrets of her past were revealed as she begins to embrace her newfound powers.");
            CastRole jace = new CastRole("Clary Fray", "2016-2019", "Jace Herondale, previously and widely known as Jace Wayland, is a " +
                "lethal and expert Shadowhunter—a skilled soldier in their war against demons.");

            //Shadowhunters Cast Members
            CastMember matt = new CastMember(new Name("Matthew", "Daddario"), new DateTime(1987, 10, 01), alec,
                "Matthew Daddario was born and raised in New York to Richard and Christina Daddario, both lawyers. " +
                "He studied business at Indiana University in Bloomington. He graduated in 2010, after which he began " +
                "studying acting and started auditioning. ", 5,
                "https://www.imdb.com/name/nm4568989/", "ms-appx:///Images/matt.jpg");

            CastMember kat = new CastMember(new Name("Katherine", "McNamera"), new DateTime(1995, 11, 22), clary,
            "Katherine McNamara, named one of Vanity Fair's 'Breakout Bunch', is an accomplished actor, dancer, " +
            "singer/songwriter and was just awarded the 2018 People's Choice Award for Top Female Television Actress " +
            "for her leading role of 'Clary Fray' in the Freeform series, Shadowhunters", 1,
            "https://www.imdb.com/name/nm4123601/?ref_=tt_cl_t2", "ms-appx:///Images/katherine.jpg");

            CastMember dom = new CastMember(new Name("Dominic", "Sherwood"), new DateTime(1990, 02, 06), jace,
            "Actor Dominic Anthony Sherwood was born in Kent, South East England. After studying Drama and Theater " +
            "Studies at schools in Maidstone, he left to work abroad starting in Kenya and moving for 6 months before " +
            "returning to London. ", 1,
            "https://www.imdb.com/name/nm8510480/?ref_=tt_cl_t8", "ms-appx:///Images/dom.jpg");

            List<CastMember> castMembersSH = new List<CastMember>();

            castMembersSH.Add(matt);
            castMembersSH.Add(kat);
            castMembersSH.Add(dom);

            shadowhunters = new TV_Show("Shadowhunters", "ms-appx:///Images/sh.jpg", "2016", "Sci-Fi", "Freeform", "Ended",
            "After her mother disappears, Clary must venture into the dark world of demon " +
            "hunting, and embrace her new role among the Shadowhunters.", 3, "https://www.youtube.com/watch?v=nA6nGwUwLt4", castMembersSH);

            //12 Monkeys

            CastRole cole = new CastRole("James Cole", "2015-2018", "James William Cole is a time traveler who works with Project Splinter " +
                "to stop the apocolypse. After being captured by the security of the Temporal Facility, Cole and his friend Jose Ramse are " +
                "allowed safe haven within the Temporal Facility in exchange for James' cooperation in Project Splinter's mission to prevent " +
                "the Kalavirus outbreak through the use of time travel.");
            CastRole cassie = new CastRole("Cassandra Railly", "2015-2018", "Dr. Cassandra Railly is a character on 12 Monkeys. She is a " +
                "virologist while she worked for the CDC. After meeting a time traveler from the future, James Cole, she worked with him " +
                "to help prevent the coming apocolypse. After being fataly injured, she was sent to the future where she was treated and " +
                "became a time traveler along with the other members with Project Splinter.");
            CastRole jennifer = new CastRole("Jennifer Goines", "2015-2018", "Jennifer Goines is a Primary, meaning she is connected to time " +
                "and as a result has visions of events that are destined to happen in the future. Jennifer Goines was born August 28, 1985. " +
                "She was brilliant but mentally unstable from an early age. When she was a child, her mother, who called her a monster, " +
                "attempted to drown her in a bathtub; a maid intervened. Jennifer's father, Leland Goines, had Jennifer's mother committed " +
                "to a mental institution. As an adult, she worked as a scientist at the Markridge Group.");

            //12 Monkeys Cast Members

            CastMember aaronS = new CastMember(new Name("Aaron", "Stanford"), new DateTime(1976, 12, 27), cole,
                "An actor who consistently brings intensity and intelligence to his work, Aaron Stanford is poised " +
                "to become one of the foremost talents of his generation. Aaron received critical acclaim for his " +
                "feature film debut in _Tadpole_ opposite Sigourney Weaver and Bebe Neuwirth. Since that breakout " +
                "performance, he has continued to tackle a variety of roles.", 5,
                "https://www.imdb.com/name/nm0822155/?ref_=nmbio_bio_nm", "ms-appx:///Images/aaron1.jpg");

            CastMember amanda = new CastMember(new Name("Amanda", "Schull"), new DateTime(1978, 8, 26), cassie,
            "Amanda Schull was born on August 26, 1978 in Honolulu, Hawaii, USA. She is an actress, known for 12 Monkeys (2015), Suits (2011) and Pretty Little Liars (2010).", 3,
            "https://www.imdb.com/name/nm0776040/?ref_=tt_ov_st_sm", "ms-appx:///Images/amanda.jpg");

            CastMember emily = new CastMember(new Name("Emily", "Hampshire"), new DateTime(1981, 8, 29), jennifer,
            "Born and raised in Montreal, Emily Hampshire has made an indelible mark on the Canadian film and television industry " +
            "in a relatively short period of time. Her work has been recognized by the Canadian Academy of Cinema and Television with " +
            "3 Genie Award Nominations, a Gemini Award for her work on the small screen and was chosen by her peers in the Canadian " +
            "Actors Guild as a nominee for 'Outstanding Female Performance' at the ACTRA Awards.", 5,
            "https://www.imdb.com/name/nm0358922/?ref_=nmbio_bio_nm", "ms-appx:///Images/emily.jpg");

            List<CastMember> castMembers12M = new List<CastMember>();

            castMembers12M.Add(aaronS);
            castMembers12M.Add(amanda);
            castMembers12M.Add(emily);

            twelveMonkeys = new TV_Show("12 Monkeys", "ms-appx:///Images/12Monkeys.jpg", "2015", "Sci-Fi", "SyFy", "Ended",
            "Follows the journey of a time traveler from the post-apocalyptic future who appears in present day " +
            "on a mission to locate and eradicate the source of a deadly plague that will nearly destroy the human race.", 5,
            "https://www.youtube.com/watch?v=wZNcVYqnCFw", castMembers12M);          
        }
    }
}

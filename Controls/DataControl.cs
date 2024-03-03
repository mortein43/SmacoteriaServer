using SmacoteriaBDFinal.Model.DataUnitOfWork;
using SmacoteriaBDFinal.Model.Models;
namespace SmacoteriaBDFinal.Controls;

public static class DataControl
{
    public static UnitOfWork unitOfWork = new UnitOfWork();

    /*public static void FillData()
    {
        using (DataContext dc = new DataContext())
        {
            //var croissantsandwiches = new Category { Name = "Круасани сендвічі" };

            var vegetarian = new Dish { Name = "Вегетаіанський", Photo = "/Photos/CroissantSandwiches/vegetarianskyj.png", Description = "круасан, соус песто, рукола, помідор, сир моцарела, в'ялені томати", Price = 105, Count = 185, CountType = Dish.CountTypes.г };
            var yalovychyna_gryl = new Dish { Name = "З яловичиною гриль", Photo = "/Photos/CroissantSandwiches/yalovychyna-gryl-croissant.png", Description = "круасан, яловичина гриль, салат айсберг, помідор, маринована цибуля, соус сацебелі, соус класичний", Price = 139, Count = 250, CountType = Dish.CountTypes.г };
            var chiz = new Dish { Name = "Чізбургер", Photo = "/Photos/CroissantSandwiches/chiz-1.png", Description = "круасан, яловича котлета, сир тостовий, салат айсберг, помідор, квашений огірок, цибуля сушена, соус гострий / соус бургерний", Price = 119, Count = 250, CountType = Dish.CountTypes.г };
            var double_chiz = new Dish { Name = "Дабл Чізбургер", Photo = "/Photos/CroissantSandwiches/chiz-1.png", Description = "круасан, яловича котлета, сир тостовий, салат айсберг, помідор, квашений огірок, цибуля сушена, соус гострий / соус бургерний", Price = 149, Count = 330, CountType = Dish.CountTypes.г };
            var kurka_teryyaki = new Dish { Name = "Курка Теріякі", Photo = "/Photos/CroissantSandwiches/kurka-teryyaki-na-sajt-v-osnovne-menyu-1.png", Description = "круасан, курка, салат, огірок, імбир маринований, кунжут, соус теріякі", Price = 109, Count = 240, CountType = Dish.CountTypes.г };
            var galytskyj = new Dish { Name = "Галицький", Photo = "/Photos/CroissantSandwiches/Galytskyj.png", Description = "круасан, огірок, помідор, курка, гриби, салат, соус гірчичний", Price = 89, Count = 239, CountType = Dish.CountTypes.г };
            var amsterdam = new Dish { Name = "Амстердам", Photo = "/Photos/CroissantSandwiches/Amsterdam.png", Description = "круасан, оселедець, сир моцарела, помідор, салат, соус песто, соус часниковий", Price = 97, Count = 225, CountType = Dish.CountTypes.г };
            var z_tuentsem = new Dish { Name = "З тунцем", Photo = "/Photos/CroissantSandwiches/z-tuentsem.png", Description = "круасан, зелена цибуля, тунець, яєчня, лимон, помідор, салат, соус класичний", Price = 105, Count = 245, CountType = Dish.CountTypes.г };
            var korolivskyj = new Dish { Name = "Королівський", Photo = "/Photos/CroissantSandwiches/Korolivskyj.png", Description = "круасан, помідор, салат, сир королівський, курка, соус гірчичний", Price = 109, Count = 240, CountType = Dish.CountTypes.г };
            var lvivskyj = new Dish { Name = "Львівський", Photo = "/Photos/CroissantSandwiches/Lvivskyj.png", Description = "круасан, огірок, помідор, салямі, сир тостовий, яєчня, салат, соус часниковий", Price = 89, Count = 240, CountType = Dish.CountTypes.г };
            var myslyvskyj = new Dish { Name = "Мисливський", Photo = "/Photos/CroissantSandwiches/myslyvskyj.png", Description = "круасан, квашений огірок, ковбаски мисливські, яєчня, салат, соус гострий", Price = 105, Count = 245, CountType = Dish.CountTypes.г };
            var selyanskyj = new Dish { Name = "Селянський", Photo = "/Photos/CroissantSandwiches/Selyanskyj.png", Description = "круасан, квашений огірок, балик, маринована цибуля, салат, соус часниковий", Price = 95, Count = 200, CountType = Dish.CountTypes.г };
            var losos_filadelfiya = new Dish { Name = "Філадельфія з лососем", Photo = "/Photos/CroissantSandwiches/losos-filadelfiya.png", Description = "круасан, сир філадельфія, лосось, салат, огірок", Price = 145, Count = 187, CountType = Dish.CountTypes.г };
            var ovochevyj = new Dish { Name = "Філадельфія з овочами", Photo = "/Photos/CroissantSandwiches/ovochevyj.png", Description = "круасан, сир філадельфія, салат, огірок, помідор", Price = 95, Count = 190, CountType = Dish.CountTypes.г };
            var shynka_filadelfiya = new Dish { Name = "Філадельфія з шинкою", Photo = "/Photos/CroissantSandwiches/SHynka-filadelfiya.png", Description = "круасан, сир філадельфія, шинка, помідор, салат, яєчня, соус класичний", Price = 115, Count = 247, CountType = Dish.CountTypes.г };
            var tsezar_z_kurkoyu = new Dish { Name = "Цезар з куркою", Photo = "/Photos/CroissantSandwiches/TSezar-z-kurkoyu.png", Description = "круасан, курка, помідор, сир пармезан, салат айсберг, соус цезар", Price = 109, Count = 226, CountType = Dish.CountTypes.г };

            var buljon = new Dish { Name = "Курячий бульйон", Photo = "/Photos/CroissantSandwiches/buljon-zhovtyj-stakan.png", Description = "курячий бульйон", Price = 39, Count = 281, CountType = Dish.CountTypes.г };
            var porichka = new Dish { Name = "З перетертою чорною порічкою та ніжним йогуртовим кремом", Photo = "/Photos/SweetCroissant/porichka.png", Description = "круасан, перетерта порічка, сублімована чорниця, крем йогуртовий, м'ята, цукрова пудра", Price = 95, Count = 218, CountType = Dish.CountTypes.г };
            var mygdalevyj = new Dish { Name = "З мигдалевим кремом", Photo = "/Photos/SweetCroissant/Mygdalevyj.png", Description = "круасан, крем мигдалевий, мигдалеві пластівці, цукрова пудра", Price = 89, Count = 175, CountType = Dish.CountTypes.г };
            var z_shokoladom_bananom = new Dish { Name = "З шоколадом та бананом", Photo = "/Photos/SweetCroissant/Z-shokoladom-ananom.png", Description = "круасан, шоколад, банан, цукрова пудра", Price = 85, Count = 176, CountType = Dish.CountTypes.г };
            var malynova_nasoloda = new Dish { Name = "Малинова насолода", Photo = "/Photos/SweetCroissant/Malynova-nasoloda.png", Description = "круасан, вершковий крем, джем малина, м'ята, цукрова пудра", Price = 79, Count = 196, CountType = Dish.CountTypes.г };
            var pyana_vyshnya = new Dish { Name = "П’яна вишня", Photo = "/Photos/SweetCroissant/Ostannya-Pyana-vyshnya-na-dodatok.png", Description = "круасан, конфітюр \"п'яна вишня\", крем маскарпоне, какао, цукрова пудра", Price = 89, Count = 177, CountType = Dish.CountTypes.г };
            var krem_late_snikers = new Dish { Name = "Крем – Лате \"Снікерс\"", Photo = "/Photos/Drinks/krem-late-snikers.png", Description = " ", Price = 65, Count = 320, CountType = Dish.CountTypes.мл };
            var krem_lae_karamel = new Dish { Name = "Крем – Лате \"Солона карамель\"", Photo = "/Photos/Drinks/krem-lae-karamel.png", Description = " ", Price = 65, Count = 320, CountType = Dish.CountTypes.мл };
            var kapuchyno_s = new Dish { Name = "Капучино S", Photo = "/Photos/Drinks/kapuchyno-l.png", Description = " ", Price = 39, Count = 110, CountType = Dish.CountTypes.мл };
            var kapuchyno_m = new Dish { Name = "Капучино M", Photo = "/Photos/Drinks/kapuchyno-l.png", Description = " ", Price = 49, Count = 250, CountType = Dish.CountTypes.мл };
            var kapuchyno_l = new Dish { Name = "Капучино L", Photo = "/Photos/Drinks/kapuchyno-l.png", Description = " ", Price = 55, Count = 350, CountType = Dish.CountTypes.мл };
            var holodne_kapuchyno_m = new Dish { Name = "Холодне капучино M", Photo = "/Photos/Drinks/kapuchyno-l.png", Description = " ", Price = 49, Count = 250, CountType = Dish.CountTypes.мл };
            var late_s = new Dish { Name = "Лате S", Photo = "/Photos/Drinks/late-s.png", Description = " ", Price = 42, Count = 110, CountType = Dish.CountTypes.мл };
            var late_m = new Dish { Name = "Лате M", Photo = "/Photos/Drinks/late-s.png", Description = " ", Price = 52, Count = 250, CountType = Dish.CountTypes.мл };
            var late_l = new Dish { Name = "Лате L", Photo = "/Photos/Drinks/late-s.png", Description = " ", Price = 59, Count = 350, CountType = Dish.CountTypes.мл };
            var holodne_late_m = new Dish { Name = "Холодне лате M", Photo = "/Photos/Drinks/late-s.png", Description = " ", Price = 52, Count = 250, CountType = Dish.CountTypes.мл };
            var americano = new Dish { Name = "Американо", Photo = "/Photos/Drinks/americano.png", Description = " ", Price = 32, Count = 110, CountType = Dish.CountTypes.мл };
            var espreso = new Dish { Name = "Еспресо", Photo = "/Photos/Drinks/americano.png", Description = " ", Price = 26, Count = 110, CountType = Dish.CountTypes.мл };
            var ristreto = new Dish { Name = "Рістрето", Photo = "/Photos/Drinks/americano.png", Description = " ", Price = 26, Count = 110, CountType = Dish.CountTypes.мл };
            var dopio = new Dish { Name = "Допіо", Photo = "/Photos/Drinks/americano.png", Description = " ", Price = 39, Count = 110, CountType = Dish.CountTypes.мл };
            var flet_white = new Dish { Name = "Флет Вайт", Photo = "/Photos/Drinks/americano.png", Description = " ", Price = 45, Count = 110, CountType = Dish.CountTypes.мл };
            var kakao = new Dish { Name = "Какао", Photo = "/Photos/Drinks/kakao.png", Description = " ", Price = 49, Count = 250, CountType = Dish.CountTypes.мл };
            var molochnyj = new Dish { Name = "Коктейль молочний з бананом", Photo = "/Photos/Drinks/molochnyj.png", Description = " ", Price = 69, Count = 400, CountType = Dish.CountTypes.мл };
            var molochno_yagidnyj = new Dish { Name = "Коктейль молочний з бананом та ягодами", Photo = "/Photos/Drinks/molochno-yagidnyj.png", Description = " ", Price = 79, Count = 400, CountType = Dish.CountTypes.мл };
            var lumon_myata = new Dish { Name = "Вода з м’ятою та лимоном", Photo = "/Photos/Drinks/mohito.png", Description = " ", Price = 23, Count = 400, CountType = Dish.CountTypes.мл };
            var lymonad = new Dish { Name = "Лимонад класичний", Photo = "/Photos/Drinks/lymonad.png", Description = " ", Price = 49, Count = 400, CountType = Dish.CountTypes.мл };
            var mohito = new Dish { Name = "Мохіто", Photo = "/Photos/Drinks/mohito.png", Description = " ", Price = 59, Count = 400, CountType = Dish.CountTypes.мл };
            var apelsyn_myata = new Dish { Name = "Чай вітамінний \"Апельсиновий з м’ятою\"", Photo = "/Photos/Drinks/Apelsyn-myata.png", Description = " ", Price = 49, Count = 200, CountType = Dish.CountTypes.мл };
            var imbyr_med_lajm = new Dish { Name = "Чай вітамінний \"Імбир, лайм та мед\"", Photo = "/Photos/Drinks/imbyr-med-lajm.png", Description = " ", Price = 49, Count = 200, CountType = Dish.CountTypes.мл };
            var oblipyha_i_chebrets = new Dish { Name = "Чай вітамінний \"З обліпихою та чебрецем\"", Photo = "/Photos/Drinks/Oblipyha-i-chebrets.png", Description = " ", Price = 49, Count = 200, CountType = Dish.CountTypes.мл };
            var yagody_godzhi_lymon = new Dish { Name = "Чай вітамінний \"Ягоди годжі з лимоном\"", Photo = "/Photos/Drinks/YAgody-godzhi-lymon.png", Description = " ", Price = 49, Count = 200, CountType = Dish.CountTypes.мл };
            var zelenyj_vysokogirnyj = new Dish { Name = "Чай \"Зелений високогірний\"", Photo = "/Photos/Drinks/zelenyj-vysokogirnyj.png", Description = " ", Price = 33, Count = 200, CountType = Dish.CountTypes.мл };
            var kenijskyj = new Dish { Name = "Чай \"Кенійський\"", Photo = "/Photos/Drinks/kenijskyj.png", Description = "1", Price = 33, Count = 200, CountType = Dish.CountTypes.мл };
            var korliskyj_desert = new Dish { Name = "Чай \"Королівський десерт\"", Photo = "/Photos/Drinks/korliskyj-desert.png", Description = " ", Price = 33, Count = 200, CountType = Dish.CountTypes.мл };
            var ser_charlz_grej = new Dish { Name = "Чай \"Сер Чарльз Грей\"", Photo = "/Photos/Drinks/ser-CHarlz-grej.png", Description = " ", Price = 33, Count = 200, CountType = Dish.CountTypes.мл };
            var morokanska_myata = new Dish { Name = "Чай \"Марокканська м’ята\"", Photo = "/Photos/Drinks/morokanska-myata.png", Description = " ", Price = 33, Count = 200, CountType = Dish.CountTypes.мл };
            var asam_mokalbar = new Dish { Name = "Чай фірмовий \"Асам Мокалбарі\"", Photo = "/Photos/Drinks/asam-mokalbar.png", Description = " ", Price = 39, Count = 200, CountType = Dish.CountTypes.мл };
            var bilyj_angel = new Dish { Name = "Чай фірмовий \"Білий Ангел\"", Photo = "/Photos/Drinks/bilyj-angel.png", Description = " ", Price = 39, Count = 200, CountType = Dish.CountTypes.мл };
            var karnaval = new Dish { Name = "Чай фірмовий \"Карнавал\"", Photo = "/Photos/Drinks/karnaval.png", Description = "1", Price = 39, Count = 200, CountType = Dish.CountTypes.мл };
            var sad_kohanya = new Dish { Name = "Чай фірмовий \"Сад кохання\"", Photo = "/Photos/Drinks/sad-kohanya.png", Description = "1", Price = 39, Count = 200, CountType = Dish.CountTypes.мл };
            var tropichna_fantaziya = new Dish { Name = "Чай фірмовий \"Тропічна фантазія\"", Photo = "/Photos/Drinks/tropichna-fantaziya.png", Description = " ", Price = 39, Count = 200, CountType = Dish.CountTypes.мл };
            var hram_neba = new Dish { Name = "Чай фірмовий \"Храм неба\"", Photo = "/Photos/Drinks/hram-neba.png", Description = " ", Price = 39, Count = 200, CountType = Dish.CountTypes.мл };
            var croissantsandwich = new Dish { Name = "Круасан сендвіч", Photo = "/Photos/CreateOwn/ovochevyj-1.png", Description = " ", Price = 45, Count = 165, CountType = Dish.CountTypes.г };
            var sweetcroissant = new Dish { Name = "Круасан солодкий", Photo = "/Photos/CreateOwn/krua.png", Description = " ", Price = 35, Count = 90, CountType = Dish.CountTypes.г };

            var croissantsandwiches = new Category { Name = "Круасани сендвічі", Dishes = { vegetarian, yalovychyna_gryl, chiz, double_chiz, kurka_teryyaki, galytskyj, amsterdam, z_tuentsem, korolivskyj, lvivskyj, myslyvskyj, selyanskyj, losos_filadelfiya, ovochevyj, shynka_filadelfiya, tsezar_z_kurkoyu, buljon, croissantsandwich, } };
            var sweetcroissants = new Category { Name = "Солодкі круасани", Dishes = { porichka, mygdalevyj, z_shokoladom_bananom, malynova_nasoloda, pyana_vyshnya, sweetcroissant, } };
            var drinks = new Category { Name = "Напої", Dishes = { krem_late_snikers, krem_lae_karamel, kapuchyno_s, kapuchyno_m, kapuchyno_l, holodne_kapuchyno_m, late_s, late_m, late_l, holodne_late_m, americano, espreso, ristreto, dopio, flet_white, kakao, molochnyj, molochno_yagidnyj, lumon_myata, lymonad, mohito, apelsyn_myata, imbyr_med_lajm, oblipyha_i_chebrets, yagody_godzhi_lymon, zelenyj_vysokogirnyj, kenijskyj, korliskyj_desert, ser_charlz_grej, morokanska_myata, asam_mokalbar, bilyj_angel, karnaval, sad_kohanya, tropichna_fantaziya, hram_neba } };
            //var createown = new Category { Name = "Створи свій власний", Dishes = { croissantsandwich, sweetcroissant } };

            var chicken = new Addition { Name = "Курка", Photo = "/Photos/Additions/kurka.png", Price = 31, Count = 40, CountType = Addition.CountTypes.г, Category = croissantsandwiches };
            var shynka = new Addition { Name = "Шинка", Photo = "/Photos/Additions/shynka.png", Price = 39, Count = 50, CountType = Addition.CountTypes.г, Category = croissantsandwiches };
            var salyami = new Addition { Name = "Салямі", Photo = "/Photos/Additions/salyami.png", Price = 29, Count = 20, CountType = Addition.CountTypes.г, Category = croissantsandwiches };
            var kvashenyj_girok = new Addition { Name = "Квашений огірок", Photo = "/Photos/Additions/kvashenyj-ogirok.png", Price = 16, Count = 35, CountType = Addition.CountTypes.г, Category = croissantsandwiches };
            var halapeno = new Addition { Name = "Перець гострий Jalapeño", Photo = "/Photos/Additions/halapeno.png", Price = 17, Count = 8, CountType = Addition.CountTypes.г, Category = croissantsandwiches };
            var gryby = new Addition { Name = "Гриби", Photo = "/Photos/Additions/gryby.png", Price = 26, Count = 30, CountType = Addition.CountTypes.г, Category = croissantsandwiches };
            var proshuto = new Addition { Name = "Прошуто", Photo = "/Photos/Additions/proshuto.png", Price = 35, Count = 20, CountType = Addition.CountTypes.г, Category = croissantsandwiches };
            var syr_korolivskyj = new Addition { Name = "Сир Королівський", Photo = "/Photos/Additions/Korolivskyj.png", Price = 31, Count = 30, CountType = Addition.CountTypes.г, Category = croissantsandwiches };
            var motsarela = new Addition { Name = "Сир Моцарела", Photo = "/Photos/Additions/motsarela.png", Price = 28, Count = 30, CountType = Addition.CountTypes.г, Category = croissantsandwiches };
            var syr_tostovyj = new Addition { Name = "Сир тостовий", Photo = "/Photos/Additions/syr-tostovyj.png", Price = 22, Count = 15, CountType = Addition.CountTypes.г, Category = croissantsandwiches };
            var losos = new Addition { Name = "Лосось", Photo = "/Photos/Additions/losos.png", Price = 73, Count = 40, CountType = Addition.CountTypes.г, Category = croissantsandwiches };
            var oseledets = new Addition { Name = "Оселедець", Photo = "/Photos/Additions/oseledets.png", Price = 30, Count = 40, CountType = Addition.CountTypes.г, Category = croissantsandwiches };
            var yajtsya = new Addition { Name = "Яєчня", Photo = "/Photos/Additions/yajtsya.png", Price = 25, Count = 40, CountType = Addition.CountTypes.г, Category = croissantsandwiches };
            var banan = new Addition { Name = "Банан", Photo = "/Photos/Additions/banan.png", Price = 24, Count = 50, CountType = Addition.CountTypes.г, Category = sweetcroissants };
            var dzhem = new Addition { Name = "Джем", Photo = "/Photos/Additions/dzhem.png", Price = 22, Count = 40, CountType = Addition.CountTypes.г, Category = sweetcroissants };
            var zgushhene_moloko = new Addition { Name = "Згущене молоко", Photo = "/Photos/Additions/zgushhene-moloko.png", Price = 22, Count = 35, CountType = Addition.CountTypes.г, Category = sweetcroissants };
            var morozyvo = new Addition { Name = "Морозиво", Photo = "/Photos/Additions/morozyvo.png", Price = 23, Count = 70, CountType = Addition.CountTypes.г, Category = sweetcroissants };
            var shokolad = new Addition { Name = "Шоколад", Photo = "/Photos/Additions/shokolad.png", Price = 29, Count = 35, CountType = Addition.CountTypes.г, Category = sweetcroissants };

            unitOfWork.DishRepository.InsertRange(new List<Dish> { vegetarian, yalovychyna_gryl, chiz, double_chiz, kurka_teryyaki, galytskyj, amsterdam, z_tuentsem, korolivskyj, lvivskyj, myslyvskyj, selyanskyj, losos_filadelfiya, ovochevyj, shynka_filadelfiya, tsezar_z_kurkoyu, buljon, porichka, mygdalevyj, z_shokoladom_bananom, malynova_nasoloda, pyana_vyshnya, krem_late_snikers, krem_lae_karamel, kapuchyno_s, kapuchyno_m, kapuchyno_l, holodne_kapuchyno_m, late_s, late_m, late_l, holodne_late_m, americano, espreso, ristreto, dopio, flet_white, kakao, molochnyj, molochno_yagidnyj, lumon_myata, lymonad, mohito, apelsyn_myata, imbyr_med_lajm, oblipyha_i_chebrets, yagody_godzhi_lymon, zelenyj_vysokogirnyj, kenijskyj, korliskyj_desert, ser_charlz_grej, morokanska_myata, asam_mokalbar, bilyj_angel, karnaval, sad_kohanya, tropichna_fantaziya, hram_neba, sweetcroissant, croissantsandwich });
            unitOfWork.AdditionRepository.InsertRange(new List<Addition> { chicken, shynka, salyami, kvashenyj_girok, halapeno, gryby, proshuto, syr_korolivskyj, motsarela, syr_tostovyj, losos, oseledets, yajtsya, banan, dzhem, zgushhene_moloko, morozyvo, shokolad });
            unitOfWork.CategoryRepository.InsertRange(new List<Category> { croissantsandwiches, sweetcroissants, drinks });
            unitOfWork.Save();

            //TCPControl tCPControl = new TCPControl(unitOfWork.DishRepository.GetAll(), unitOfWork.AdditionRepository.GetAll());
        }

    }*/

    /*public static void FillData()
    {
        using (var dbContext = new DataContext())
        {
            // Витягуємо всі страви з бази даних
            var dishes = dbContext.Dishes.ToList();
            var additions = dbContext.Additions.ToList();
            var categories = dbContext.Categories.ToList();
            // Додаємо всі страви до unitOfWork
            unitOfWork.DishRepository.InsertRange(dishes);
            unitOfWork.AdditionRepository.InsertRange(additions);
            unitOfWork.CategoryRepository.InsertRange(categories);

            //unitOfWork.Save();
        }
    }*/

    public static List<Dish> GetDishes()
    {
        var dishes = unitOfWork.DishRepository.GetAll();
        return dishes;
    }

    public static List<Addition> GetAdditions()
    {
        return unitOfWork.AdditionRepository.GetAll();
    }

}

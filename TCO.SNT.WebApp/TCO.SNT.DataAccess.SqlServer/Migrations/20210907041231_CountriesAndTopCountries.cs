using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class CountriesAndTopCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                table: "FavouriteCurrencies",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRu = table.Column<string>(maxLength: 254, nullable: true),
                    Alpha2 = table.Column<string>(maxLength: 2, nullable: true),
                    Alpha3 = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteCountries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteCountries", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_FavouriteCountries_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.Sql(@"INSERT INTO Countries (NameRu, Alpha2, Alpha3) VALUES
                        (N'Австралия','au','aus'),
                        (N'Австрия','at','aut'),
                        (N'Азербайджан','az','aze'),
                        (N'Аландские острова','ax','ala'),
                        (N'Албания','al','alb'),
                        (N'Алжир','dz','dza'),
                        (N'Виргинские Острова (США)','vi','vir'),
                        (N'Американское Самоа','as','asm'),
                        (N'Ангилья','ai','aia'),
                        (N'Ангола','ao','ago'),
                        (N'Андорра','ad','and'),
                        (N'Антарктика','aq','ata'),
                        (N'Антигуа и Барбуда','ag','atg'),
                        (N'Аргентина','ar','arg'),
                        (N'Армения','am','arm'),
                        (N'Аруба','aw','abw'),
                        (N'Афганистан','af','afg'),
                        (N'Багамские Острова','bs','bhs'),
                        (N'Бангладеш','bd','bgd'),
                        (N'Барбадос','bb','brb'),
                        (N'Бахрейн','bh','bhr'),
                        (N'Белиз','bz','blz'),
                        (N'Белоруссия','by','blr'),
                        (N'Бельгия','be','bel'),
                        (N'Бенин','bj','ben'),
                        (N'Бермуды','bm','bmu'),
                        (N'Болгария','bg','bgr'),
                        (N'Боливия','bo','bol'),
                        (N'Бонайре, Синт-Эстатиус и Саба','bq','bes'),
                        (N'Босния и Герцеговина','ba','bih'),
                        (N'Ботсвана','bw','bwa'),
                        (N'Бразилия','br','bra'),
                        (N'Британская территория в Индийском океане','io','iot'),
                        (N'Виргинские Острова (Великобритания)','vg','vgb'),
                        (N'Бруней','bn','brn'),
                        (N'Буркина-Фасо','bf','bfa'),
                        (N'Бурунди','bi','bdi'),
                        (N'Бутан','bt','btn'),
                        (N'Вануату','vu','vut'),
                        (N'Ватикан','va','vat'),
                        (N'Великобритания','gb','gbr'),
                        (N'Венгрия','hu','hun'),
                        (N'Венесуэла','ve','ven'),
                        (N'Внешние малые острова США','um','umi'),
                        (N'Восточный Тимор','tl','tls'),
                        (N'Вьетнам','vn','vnm'),
                        (N'Габон','ga','gab'),
                        (N'Гаити','ht','hti'),
                        (N'Гайана','gy','guy'),
                        (N'Гамбия','gm','gmb'),
                        (N'Гана','gh','gha'),
                        (N'Гваделупа','gp','glp'),
                        (N'Гватемала','gt','gtm'),
                        (N'Гвиана','gf','guf'),
                        (N'Гвинея','gn','gin'),
                        (N'Гвинея-Бисау','gw','gnb'),
                        (N'Германия','de','deu'),
                        (N'Гернси','gg','ggy'),
                        (N'Гибралтар','gi','gib'),
                        (N'Гондурас','hn','hnd'),
                        (N'Гонконг','hk','hkg'),
                        (N'Гренада','gd','grd'),
                        (N'Гренландия','gl','grl'),
                        (N'Греция','gr','grc'),
                        (N'Грузия','ge','geo'),
                        (N'Гуам','gu','gum'),
                        (N'Дания','dk','dnk'),
                        (N'Джерси','je','jey'),
                        (N'Джибути','dj','dji'),
                        (N'Доминика','dm','dma'),
                        (N'Доминиканская Республика','do','dom'),
                        (N'ДР Конго','cd','cod'),
                        (N'Египет','eg','egy'),
                        (N'Замбия','zm','zmb'),
                        (N'САДР','eh','esh'),
                        (N'Зимбабве','zw','zwe'),
                        (N'Израиль','il','isr'),
                        (N'Индия','in','ind'),
                        (N'Индонезия','id','idn'),
                        (N'Иордания','jo','jor'),
                        (N'Ирак','iq','irq'),
                        (N'Иран','ir','irn'),
                        (N'Ирландия','ie','irl'),
                        (N'Исландия','is','isl'),
                        (N'Испания','es','esp'),
                        (N'Италия','it','ita'),
                        (N'Йемен','ye','yem'),
                        (N'Кабо-Верде','cv','cpv'),
                        (N'Казахстан','kz','kaz'),
                        (N'Острова Кайман','ky','cym'),
                        (N'Камбоджа','kh','khm'),
                        (N'Камерун','cm','cmr'),
                        (N'Канада','ca','can'),
                        (N'Катар','qa','qat'),
                        (N'Кения','ke','ken'),
                        (N'Кипр','cy','cyp'),
                        (N'Киргизия','kg','kgz'),
                        (N'Кирибати','ki','kir'),
                        (N'Китайская Республика (Тайвань)','tw','twn'),
                        (N'КНДР (Корейская Народно-Демократическая Республика)','kp','prk'),
                        (N'Китай (Китайская Народная Республика)','cn','chn'),
                        (N'Кокосовые острова','cc','cck'),
                        (N'Колумбия','co','col'),
                        (N'Коморы','km','com'),
                        (N'Коста-Рика','cr','cri'),
                        (N'Кот-д’Ивуар','ci','civ'),
                        (N'Куба','cu','cub'),
                        (N'Кувейт','kw','kwt'),
                        (N'Кюрасао','cw','cuw'),
                        (N'Лаос','la','lao'),
                        (N'Латвия','lv','lva'),
                        (N'Лесото','ls','lso'),
                        (N'Либерия','lr','lbr'),
                        (N'Ливан','lb','lbn'),
                        (N'Ливия','ly','lby'),
                        (N'Литва','lt','ltu'),
                        (N'Лихтенштейн','li','lie'),
                        (N'Люксембург','lu','lux'),
                        (N'Маврикий','mu','mus'),
                        (N'Мавритания','mr','mrt'),
                        (N'Мадагаскар','mg','mdg'),
                        (N'Майотта','yt','myt'),
                        (N'Макао','mo','mac'),
                        (N'Северная Македония','mk','mkd'),
                        (N'Малави','mw','mwi'),
                        (N'Малайзия','my','mys'),
                        (N'Мали','ml','mli'),
                        (N'Мальдивы','mv','mdv'),
                        (N'Мальта','mt','mlt'),
                        (N'Марокко','ma','mar'),
                        (N'Мартиника','mq','mtq'),
                        (N'Маршалловы Острова','mh','mhl'),
                        (N'Мексика','mx','mex'),
                        (N'Микронезия','fm','fsm'),
                        (N'Мозамбик','mz','moz'),
                        (N'Молдавия','md','mda'),
                        (N'Монако','mc','mco'),
                        (N'Монголия','mn','mng'),
                        (N'Монтсеррат','ms','msr'),
                        (N'Мьянма','mm','mmr'),
                        (N'Намибия','na','nam'),
                        (N'Науру','nr','nru'),
                        (N'Непал','np','npl'),
                        (N'Нигер','ne','ner'),
                        (N'Нигерия','ng','nga'),
                        (N'Нидерланды','nl','nld'),
                        (N'Никарагуа','ni','nic'),
                        (N'Ниуэ','nu','niu'),
                        (N'Новая Зеландия','nz','nzl'),
                        (N'Новая Каледония','nc','ncl'),
                        (N'Норвегия','no','nor'),
                        (N'ОАЭ','ae','are'),
                        (N'Оман','om','omn'),
                        (N'Остров Буве','bv','bvt'),
                        (N'Остров Мэн','im','imn'),
                        (N'Острова Кука','ck','cok'),
                        (N'Остров Норфолк','nf','nfk'),
                        (N'Остров Рождества','cx','cxr'),
                        (N'Острова Питкэрн','pn','pcn'),
                        (N'Острова Святой Елены, Вознесения и Тристан-да-Кунья','sh','shn'),
                        (N'Пакистан','pk','pak'),
                        (N'Палау','pw','plw'),
                        (N'Государство Палестина','ps','pse'),
                        (N'Панама','pa','pan'),
                        (N'Папуа — Новая Гвинея','pg','png'),
                        (N'Парагвай','py','pry'),
                        (N'Перу','pe','per'),
                        (N'Польша','pl','pol'),
                        (N'Португалия','pt','prt'),
                        (N'Пуэрто-Рико','pr','pri'),
                        (N'Республика Конго','cg','cog'),
                        (N'Республика Корея','kr','kor'),
                        (N'Реюньон','re','reu'),
                        (N'Россия','ru','rus'),
                        (N'Руанда','rw','rwa'),
                        (N'Румыния','ro','rou'),
                        (N'Сальвадор','sv','slv'),
                        (N'Самоа','ws','wsm'),
                        (N'Сан-Марино','sm','smr'),
                        (N'Сан-Томе и Принсипи','st','stp'),
                        (N'Саудовская Аравия','sa','sau'),
                        (N'Эсватини','sz','swz'),
                        (N'Северные Марианские Острова','mp','mnp'),
                        (N'Сейшельские Острова','sc','syc'),
                        (N'Сен-Бартелеми','bl','blm'),
                        (N'Сен-Мартен','mf','maf'),
                        (N'Сен-Пьер и Микелон','pm','spm'),
                        (N'Сенегал','sn','sen'),
                        (N'Сент-Винсент и Гренадины','vc','vct'),
                        (N'Сент-Китс и Невис','kn','kna'),
                        (N'Сент-Люсия','lc','lca'),
                        (N'Сербия','rs','srb'),
                        (N'Сингапур','sg','sgp'),
                        (N'Синт-Мартен','sx','sxm'),
                        (N'Сирия','sy','syr'),
                        (N'Словакия','sk','svk'),
                        (N'Словения','si','svn'),
                        (N'Соломоновы Острова','sb','slb'),
                        (N'Сомали','so','som'),
                        (N'Судан','sd','sdn'),
                        (N'Суринам','sr','sur'),
                        (N'США','us','usa'),
                        (N'Сьерра-Леоне','sl','sle'),
                        (N'Таджикистан','tj','tjk'),
                        (N'Таиланд','th','tha'),
                        (N'Танзания','tz','tza'),
                        (N'Теркс и Кайкос','tc','tca'),
                        (N'Того','tg','tgo'),
                        (N'Токелау','tk','tkl'),
                        (N'Тонга','to','ton'),
                        (N'Тринидад и Тобаго','tt','tto'),
                        (N'Тувалу','tv','tuv'),
                        (N'Тунис','tn','tun'),
                        (N'Туркмения','tm','tkm'),
                        (N'Турция','tr','tur'),
                        (N'Уганда','ug','uga'),
                        (N'Узбекистан','uz','uzb'),
                        (N'Украина','ua','ukr'),
                        (N'Уоллис и Футуна','wf','wlf'),
                        (N'Уругвай','uy','ury'),
                        (N'Фарерские острова','fo','fro'),
                        (N'Фиджи','fj','fji'),
                        (N'Филиппины','ph','phl'),
                        (N'Финляндия','fi','fin'),
                        (N'Фолклендские острова','fk','flk'),
                        (N'Франция','fr','fra'),
                        (N'Французская Полинезия','pf','pyf'),
                        (N'Французские Южные и Антарктические территории','tf','atf'),
                        (N'Херд и Макдональд','hm','hmd'),
                        (N'Хорватия','hr','hrv'),
                        (N'ЦАР','cf','caf'),
                        (N'Чад','td','tcd'),
                        (N'Черногория','me','mne'),
                        (N'Чехия','cz','cze'),
                        (N'Чили','cl','chl'),
                        (N'Швейцария','ch','che'),
                        (N'Швеция','se','swe'),
                        (N'Шпицберген и Ян-Майен','sj','sjm'),
                        (N'Шри-Ланка','lk','lka'),
                        (N'Эквадор','ec','ecu'),
                        (N'Экваториальная Гвинея','gq','gnq'),
                        (N'Эритрея','er','eri'),
                        (N'Эстония','ee','est'),
                        (N'Эфиопия','et','eth'),
                        (N'ЮАР','za','zaf'),
                        (N'Южная Георгия и Южные Сандвичевы Острова','gs','sgs'),
                        (N'Южный Судан','ss','ssd'),
                        (N'Ямайка','jm','jam'),
                        (N'Япония','jp','jpn')");

            migrationBuilder.Sql("Update Countries Set Alpha2 = UPPER(Alpha2), Alpha3 = UPPER(Alpha3)");

            var topCountriesOrder = new List<(string, byte)>()
            {
                ("KZ", 1),
                ("RU", 2),
                ("US", 3),
                ("KG", 4),
                ("CA", 5)
            };

            topCountriesOrder.ForEach(c => migrationBuilder.Sql($"Insert into FavouriteCountries(CountryId, SortOrder) select Id, {c.Item2} from Countries where Alpha2 = '{c.Item1}'"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteCountries");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.AlterColumn<byte>(
                name: "SortOrder",
                table: "FavouriteCurrencies",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}

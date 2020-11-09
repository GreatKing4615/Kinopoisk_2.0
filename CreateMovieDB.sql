
USE [MovieDataBase]
GO
/****** Объект: Table [dbo].[Actors] Дата скрипта: 08.11.2020 12:25:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Actors] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50)  NOT NULL,
    [Bio]       NVARCHAR (MAX) NULL,
    [Birthday]  DATETIME2 (7)  NOT NULL,
    [Rating]    FLOAT (53)     NOT NULL,
    [PhotoPath] NVARCHAR (MAX) NULL
);
SET IDENTITY_INSERT [dbo].[Actors] ON
INSERT INTO [dbo].[Actors] ([Id], [Name], [Bio], [Birthday], [Rating], [PhotoPath]) VALUES (2, N'Сергей Безруков', N'с руками', N'1999-08-02 00:00:00', 100, N'http://m-g-t.ru/wp-content/uploads/2013/08/Bezrukov_TASS.jpg')
INSERT INTO [dbo].[Actors] ([Id], [Name], [Bio], [Birthday], [Rating], [PhotoPath]) VALUES (3, N'Юэн Макгрегор', N'Шотландский актёр. Лауреат премии «Золотой глобус», двукратный лауреат премии BAFTA. Актёр снимается как в независимом кино, так и в высокобюджетных голливудских проектах.', N'1971-03-31 00:00:00', 20, N'https://vignette.wikia.nocookie.net/goldenthroats/images/0/01/Ewanmcgregor.jpg/revision/latest?cb=20161128221039')
INSERT INTO [dbo].[Actors] ([Id], [Name], [Bio], [Birthday], [Rating], [PhotoPath]) VALUES (5, N'Джеймс Макэвой', N'Шотландский актёр, известный по фильмам «Грязь», «Дети Дюны», «…А в душе я танцую», «Последнее воскресение», «Искупление», «Джейн Остин», «Хроники Нарнии: Лев, колдунья и волшебный шкаф», «Последний король Шотландии», «Виктор Франкенштейн», «Добро пожаловать в капкан», «Сплит», «Стекло», «Особо опасен» и по роли Профессора Икс в фильмах «Люди Икс: Первый класс», «Люди Икс: Дни минувшего будущего», «Люди Икс: Апокалипсис» и «Люди Икс: Тёмный Феникс». Трижды номинант на премию Лоуренса Оливье, номинант на кинопремию «Золотой глобус». Лауреат премии Evening Theatre Standard Awards, BAFTA Scotland, BAFTA, Каннского кинофестиваля и других.', N'1979-04-21 00:00:00', 10, N'https://www.newdvdreleasedates.com/images/profiles/james-mcavoy-10.jpg')
INSERT INTO [dbo].[Actors] ([Id], [Name], [Bio], [Birthday], [Rating], [PhotoPath]) VALUES (6, N'Скарлетт Йоханссон', N'Американская актриса кино и телевидения, певица. Наибольшую известность ей принесло сотрудничество с Вуди Алленом и Софией Копполой, а также роль Чёрной вдовы в серии фильмов кинематографической вселенной Marvel.', N'1984-11-22 00:00:00', 16, N'https://puzzleit.ru/files/puzzles/115/115382/_original.jpg')
INSERT INTO [dbo].[Actors] ([Id], [Name], [Bio], [Birthday], [Rating], [PhotoPath]) VALUES (7, N'Леонардо Ди Каприо', N'Американский актёр и продюсер. Лауреат премии «Оскар», трёхкратный лауреат премии «Золотой глобус», лауреат премии BAFTA, обладатель «Серебряного медведя» Берлинского кинофестиваля.', N'1974-11-11 00:00:00', 30, N'https://cloudstatic.eva.ru/eva/720000-730000/722554/channel/50811376_2063385517088473_7022175769608418607_n_13230733793540612.jpg')
INSERT INTO [dbo].[Actors] ([Id], [Name], [Bio], [Birthday], [Rating], [PhotoPath]) VALUES (8, N'Лиам Ниссон', N'Британский актёр ирландского происхождения. В числе его известных актёрских работ такие фильмы, как «Список Шиндлера», «Роб Рой», «Отверженные», «Реальная любовь», «Неизвестный», «Воздушный маршал», «Молчание» и кинотрилогия «Заложница» и появление в двух из трёх фильмов трилогии Кристофера Нолана о Бэтмене, «Бэтмен: Начало» и «Тёмный рыцарь: Возрождение легенды».', N'1952-06-07 00:00:00', 25, N'https://otvet.imgsmail.ru/download/239471160_c2f2927d1ba640d738a3a54337390f07.jpg')
INSERT INTO [dbo].[Actors] ([Id], [Name], [Bio], [Birthday], [Rating], [PhotoPath]) VALUES (9, N'Александр Петров', N'Российский актёр театра и кино. Двукратный лауреат премии «Золотой орёл»: за лучшую мужскую роль в кино и за лучшую мужскую роль на телевидении.', N'1989-01-25 00:00:00', 14, N'https://avatars.mds.yandex.net/get-zen_doc/3614701/pub_5ef4f2c71000ae4a2c0d2074_5ef5af9ac068ae2ddbea9490/scale_1200')
SET IDENTITY_INSERT [dbo].[Actors] OFF

USE [MovieDataBase]
GO

/****** Объект: Table [dbo].[Movies] Дата скрипта: 08.11.2020 14:33:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movies] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [description] NVARCHAR (MAX) NULL,
    [ReleaseDate] DATETIME2 (7)  NOT NULL,
    [Rating]      FLOAT (53)     NOT NULL,
    [PhotoPath]   NVARCHAR (MAX) NULL
);

SET IDENTITY_INSERT [dbo].[Movies] ON
INSERT INTO [dbo].[Movies] ([Id], [Name], [description], [ReleaseDate], [Rating], [PhotoPath]) VALUES (5, N'Заложница', N'«Заложница» (англ. Taken — «Похищенная») — остросюжетный боевик режиссёра Пьера Мореля. Мировая премьера состоялась 27 февраля 2008 года (в России — 18 сентября 2008 года). Фильм дал старт одноимённой кинофраншизе, включающей в себя трилогию фильмов и телесериал.', N'2008-02-27 00:00:00', 8, N'https://avatars.mds.yandex.net/get-pdb/2019823/3be90b64-32d2-4a55-846b-9431ab321664/s1200?webp=false')
INSERT INTO [dbo].[Movies] ([Id], [Name], [description], [ReleaseDate], [Rating], [PhotoPath]) VALUES (7, N'Звёздные войны: Эпизод 1 – Скрытая угроза', N'Мирная и процветающая планета Набу. Торговая федерация, не желая платить налоги, вступает в прямой конфликт с королевой Амидалой, правящей на планете, что приводит к войне. На стороне королевы и республики в ней участвуют два рыцаря-джедая: учитель и ученик, Квай-Гон-Джин и Оби-Ван Кеноби...', N'1999-05-04 00:00:00', 7.9, N'https://kinocomment.ru/media/foto/2015/12/31/1014001957.jpg')
INSERT INTO [dbo].[Movies] ([Id], [Name], [description], [ReleaseDate], [Rating], [PhotoPath]) VALUES (8, N'Сплит', N'Cредь бела дня с многолюдной парковки незнакомец похищает трёх школьниц. Они приходят в себя в закрытом помещении, а в душе владельца таятся 23 лика страха. Сменяя друг друга, личности ведут обычную для них жизнь - работают и ходят к психотерапевту, периодически напоминая пленницам, что они дожидаются 24-ю личность, которая скоро явит себя миру.', N'2017-05-26 00:00:00', 7, N'https://avatars.mds.yandex.net/get-kinopoisk-image/1898899/66244461-bc57-4f36-ad81-e2633a127b6b/300x450')
INSERT INTO [dbo].[Movies] ([Id], [Name], [description], [ReleaseDate], [Rating], [PhotoPath]) VALUES (9, N'Есенин', N'Следователь МУРа, полковник Александр Хлыстов, получает по почте старинную фотографию: на ней запечатлен Есенин, только что вынутый из петли. По правилам следователь должен дать делу законный ход. Но Хлыстов, сделав себе исключение, решает заняться частным сыском и с головой погружается в изучение жизни Есенина и его загадочной гибели. В ходе расследования у Хлыстова возникает множество версий таинственных обстоятельств смерти поэта и кажется, что он уже близок к разгадке. Но события принимают неожиданный оборот…', N'2005-10-01 00:00:00', 4.2, N'https://avatars.mds.yandex.net/get-kinopoisk-image/1704946/8a76ce1e-36b4-43df-85f3-115cd97b64e8/300x450')
INSERT INTO [dbo].[Movies] ([Id], [Name], [description], [ReleaseDate], [Rating], [PhotoPath]) VALUES (11, N'Люси', N'Еще вчера она была просто сексапильной блондинкой, а сегодня - самое опасное и смертоносное создание на планете со сверхъестественными способностями и интеллектом. То, что совсем недавно лучшие умы мира считали фантастической теорией, для нее стало реальностью. И теперь из добычи она превратится в охотницу. Ее зовут Люси...', N'2014-06-25 00:00:00', 6.7, N'https://thumbs.dfs.ivi.ru/storage2/contents/3/9/2d47b3c0fa8bc66ca6a7ed293f947c.jpg')
INSERT INTO [dbo].[Movies] ([Id], [Name], [description], [ReleaseDate], [Rating], [PhotoPath]) VALUES (12, N'Волк с Уолл-стрит', N'1987 год. Джордан Белфорт становится брокером в успешном инвестиционном банке. Вскоре банк закрывается после внезапного обвала индекса Доу-Джонса. По совету жены Терезы Джордан устраивается в небольшое заведение, занимающееся мелкими акциями. Его настойчивый стиль общения с клиентами и врождённая харизма быстро даёт свои плоды. Он знакомится с соседом по дому Донни, торговцем, который сразу находит общий язык с Джорданом и решает открыть с ним собственную фирму. В качестве сотрудников они нанимают нескольких друзей Белфорта, его отца Макса и называют компанию «Стрэттон Оукмонт»...', N'2013-12-25 00:00:00', 7.9, N'https://pbs.twimg.com/media/D-o5SB0WsAA1JYt.jpg:large')
INSERT INTO [dbo].[Movies] ([Id], [Name], [description], [ReleaseDate], [Rating], [PhotoPath]) VALUES (13, N'Люди Икс: Первый класс', N'Фильм расскажет о том, как сформировались профессор Ксавьер и Магнито, о процессе основания школы профессора для детей-мутантов и, наконец, о том, что же произошло между двумя закадычными друзьями и почему они расстались.', N'2011-06-01 00:00:00', 7.7, N'https://kinoframe.net/films/46/462358/big.jpg')
INSERT INTO [dbo].[Movies] ([Id], [Name], [description], [ReleaseDate], [Rating], [PhotoPath]) VALUES (14, N'Притяжение', N'…Как только что стало известно, сбитый над Москвой неопознанный объект имеет, возможно, внеземное происхождение. Большая часть столичного Чертанова оцеплена, к месту крушения стягиваются представители силовых структур, решается вопрос об эвакуации местных жителей. По словам нашего источника в Минобороны сейчас специальная комиссия пытается вступить в контакт с так называемыми «гостями». В эти минуты мы готовим экстренный выпуск новостей, и о развитии событий вы узнаете первыми…', N'2017-01-26 00:00:00', 5.6, N'https://horrorzone.ru/uploads/_gallery/51041/pritjazhenie00.jpg')
INSERT INTO [dbo].[Movies] ([Id], [Name], [description], [ReleaseDate], [Rating], [PhotoPath]) VALUES (15, N'Го́голь. Нача́ло', N'Казаки, ведьмы, русалки, утопленницы и другие обитатели Диканьки встречаются лицом к лицу со своим создателем Николаем Гоголем, молодым писарем из Петербурга, который страдает загадочными припадками и может общаться с персонажами из потустороннего мира. Вместе со своим начальником, блестящим столичным следователем Яковом Гуро, начинающий писатель приезжает на Полтавщину расследовать таинственные убийства девушек. Здесь же он встречает свою любовь, которой суждено сыграть роковую роль в его судьбе. Но хватит ли юному литератору духу противостоять невообразимому? Ведь по слухам, которые активно разносят напуганные местные жители, за преступлениями стоит не кто иной, как сам Дьявол в обличии черного всадника.Казаки, ведьмы, русалки, утопленницы и другие обитатели Диканьки встречаются лицом к лицу со своим создателем Николаем Гоголем, молодым писарем из Петербурга, который страдает загадочными припадками и может общаться с персонажами из потустороннего мира. Вместе со своим начальником, блестящим столичным следователем Яковом Гуро, начинающий писатель приезжает на Полтавщину расследовать таинственные убийства девушек. Здесь же он встречает свою любовь, которой суждено сыграть роковую роль в его судьбе. Но хватит ли юному литератору духу противостоять невообразимому? Ведь по слухам, которые активно разносят напуганные местные жители, за преступлениями стоит не кто иной, как сам Дьявол в обличии черного всадника.', N'2017-08-31 00:00:00', 6.2, N'https://avatars.mds.yandex.net/get-kinopoisk-image/1946459/5ad7f814-8bb5-472c-b6f3-43fa75b65c46/300x450')
INSERT INTO [dbo].[Movies] ([Id], [Name], [description], [ReleaseDate], [Rating], [PhotoPath]) VALUES (18, N'Герой', N'15 лет назад Андрей под руководством своего отца, полковника Родина, прошел обучение в секретной спецшколе, где из подростков готовили агентов Службы внешней разведки. Когда экспериментальный проект закрыли, Андрей «сжёг мосты», остался в Европе и старался не вспоминать о прошлом. Но однажды ему звонит отец, которого все считали погибшим. Тот сообщает, что на Андрея открыта охота, но кто решил его уничтожить – неизвестно. Спасаясь бегством, он находит Машу, с которой учился в спецшколе. Андрею предстоит пройти через любовь и предательство и узнать об истинных масштабах беспощадной шпионской игры, в которую он оказался втянут поневоле.', N'2019-09-26 00:00:00', 5.3, N'https://avatars.mds.yandex.net/get-kinopoisk-image/1898899/0951790a-4305-4428-b6d3-b3da9e5fbb5c/300x450')
INSERT INTO [dbo].[Movies] ([Id], [Name], [description], [ReleaseDate], [Rating], [PhotoPath]) VALUES (19, N'Метод', N'Главный герой — Родион Меглин — загадочная и неординарная личность, следователь высочайшего уровня, который раскрывает самые сложные убийства. Он привык работать в одиночку, не раскрывая секреты своего метода. Выпускница юрфака Есеня получает направление в отделение полиции, в котором служит Меглин, и становится его стажером. У девушки есть личные мотивы для работы с прославленным следователем — мать Есени убили, а отец скрывает важные детали произошедшего, но она не оставляет надежды выйти на след убийцы. Работа с Меглиным становится для Есени тяжелым испытанием...', N'2015-10-18 00:00:00', 8.1, N'https://st.kp.yandex.net/im/poster/3/2/2/kinopoisk.ru--3221689--o--.jpg')
INSERT INTO [dbo].[Movies] ([Id], [Name], [description], [ReleaseDate], [Rating], [PhotoPath]) VALUES (20, N'Стрельцов', N'К 20 годам у него есть все, о чем только можно мечтать: талант, деньги, слава, любовь. Он — Эдуард Стрельцов, восходящая звезда советского футбола и кумир миллионов. Вся страна с замиранием сердца ждет побед советской сборной на предстоящем Чемпионате мира в Швеции и дуэли Стрельцова с Пеле. Но за два дня до отъезда команды недоброжелатели ломают судьбу спортсмена. Когда дорога в футбол, казалось бы, навсегда отрезана, Стрельцов должен совершить невозможное, чтобы вернуться и доказать всем, что он — чемпион. Великий спортсмен, заслуживший настоящую народную любовь.', N'2020-09-24 00:00:00', 5.8, N'https://avatars.mds.yandex.net/get-kinopoisk-image/1777765/5d867c58-3852-4686-93ac-b985260e54d0/300x450')
SET IDENTITY_INSERT [dbo].[Movies] OFF

USE [MovieDataBase]
GO

/****** Объект: Table [dbo].[MovieActors] Дата скрипта: 08.11.2020 14:34:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MovieActors] (
    [ActorId] INT NOT NULL,
    [MovieId] INT NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_MovieActors_MovieId]
    ON [dbo].[MovieActors]([MovieId] ASC);


GO
ALTER TABLE [dbo].[MovieActors]
    ADD CONSTRAINT [PK_MovieActors] PRIMARY KEY CLUSTERED ([ActorId] ASC, [MovieId] ASC);


GO
ALTER TABLE [dbo].[MovieActors]
    ADD CONSTRAINT [FK_MovieActors_Actors_ActorId] FOREIGN KEY ([ActorId]) REFERENCES [dbo].[Actors] ([Id]);


GO
ALTER TABLE [dbo].[MovieActors]
    ADD CONSTRAINT [FK_MovieActors_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movies] ([Id]);

INSERT INTO [dbo].[MovieActors] ([ActorId], [MovieId]) VALUES (8, 5)
INSERT INTO [dbo].[MovieActors] ([ActorId], [MovieId]) VALUES (3, 7)
INSERT INTO [dbo].[MovieActors] ([ActorId], [MovieId]) VALUES (8, 7)
INSERT INTO [dbo].[MovieActors] ([ActorId], [MovieId]) VALUES (5, 8)
INSERT INTO [dbo].[MovieActors] ([ActorId], [MovieId]) VALUES (2, 9)
INSERT INTO [dbo].[MovieActors] ([ActorId], [MovieId]) VALUES (6, 11)
INSERT INTO [dbo].[MovieActors] ([ActorId], [MovieId]) VALUES (7, 12)
INSERT INTO [dbo].[MovieActors] ([ActorId], [MovieId]) VALUES (5, 13)
INSERT INTO [dbo].[MovieActors] ([ActorId], [MovieId]) VALUES (9, 14)
INSERT INTO [dbo].[MovieActors] ([ActorId], [MovieId]) VALUES (9, 15)
INSERT INTO [dbo].[MovieActors] ([ActorId], [MovieId]) VALUES (9, 18)
INSERT INTO [dbo].[MovieActors] ([ActorId], [MovieId]) VALUES (9, 19)
INSERT INTO [dbo].[MovieActors] ([ActorId], [MovieId]) VALUES (9, 20)


USE [MovieDataBase]
GO

/****** Объект: Table [dbo].[Persons] Дата скрипта: 08.11.2020 14:36:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Persons] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Login]    NVARCHAR (MAX) NOT NULL,
    [Password] NVARCHAR (MAX) NOT NULL,
    [Role]     NVARCHAR (MAX) NULL
);





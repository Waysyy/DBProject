db.clients.drop()
db.personals.drop()
db.cakes.drop()
db.ingredients.drop()
db.orders.drop()
db.users.drop();
db.tokens.drop();

const users = db.users;
const clients = db.clients;
const personals = db.personals;
const cakes = db.cakes;
const ingredients = db.ingredients;
const orders = db.orders;
const tokens = db.tokens;

let nameArr = ["Матвей", " Василиса", " Полина", " Мирон", " Егор", " Амина", " Лев", " Сафия", " Татьяна", " Илья", " Алексей", " Валерия", " Кирилл", " Николай", " Нина", " Милана", " Павел", " Андрей", " Глеб", " Виктория", " Артём", " Леонид", " Иван", " Адам", " Елизавета", " Мирослава", " Роман", " Ксения", " Мелисса", " Камила", " Юлия", " Давид", " Вячеслав", " Дарья", " Софья", " Михаил", " Арина", " Александра", " Елена", " Ярослава", " Пётр", " Алина", " Дмитрий", " Анастасия", " Ирина", " Карина", " Даниэль", " Кира", " Вероника", " Ева", " Тимур", " Даниил", " Максим", " Василий", " Александр", " Мария", " Агата", " Назар", " Маргарита", " Ольга", " Никита", " Алиса", " Таисия", " Богдан", " София", " Олеся", " Зоя", " Оливия", " Екатерина", " Артемий", " Лидия", " Фёдор", " Любовь", " Анна", " Сергей", " Мирослав", " Роберт", " Каролина", " Георгий", " Арсений", " Ульяна", " Игорь", " Серафима", " Григорий", " Карим", " Стефан", " Ясмина", " Ника", " Платон", " Марк", " Евгений", " Аделина", " Али", " Святослав", " Евгения", " Тимофей", " Данила", " Ариана", " Варвара", " Макар "];
let lastnameArr = ["Ячменькова", "Дарбиняна", "Шипулин", "Якушов", "Куцак", "Абдулова", "Золотарева", "Клиев", "Круминь", "Яйцов", "Сучков", "Абоймова", "Зубков", "Ермилов", "Фролова", "Калганов", "Толмачёва", "Гадолина", "Чукреева", "Кальченко", "Истомина", "Ян", "Ремизов", "Горячева", "Пайков", "Панькива", "Хабалов", "Тимирёв", "Мартьянова", "Жеглов", "Абрамович", "Шапошникова", "Раскатов", "Другаль", "Северинова", "Сыропоршнева", "Снегирева", "Дементьева", "Ухова", "Мартьянова", "Караев", "Дружинин", "Нагибина", "Дворникова", "Аводков", "Дюженкова", "Зёмина", "Шайнюк", "Медведков", "Канаев", "Сурков", "Курдина", "Сагадеев", "Богатырёв", "Козловский", "Кочеткова", "Халимдаров", "Гладков", "Ярина", "Элинский", "Крутой", "Лопатина", "Кобелев", "Янушкене", "Сиясинов", "Вьялицына", "Невшупа", "Рязанцева", "Дюженков", "Халимдаров", "Белкина", "Драгомирова", "Потрепалов", "Бурда", "Ельцина", "Еркулаева", "Шкловский", "Прибыльнова", "Яхненко", "Блок", "Соломахин", "Куликова", "Коченкова", "Малкина", "Панкина", "Шмелев", "Саитов", "Энгалычев", "Цой", "Кахманова", "Карантирова", "Кологреева", "Царско", "Щередин", "Большакова", "Эсаулова", "Дубин", "Казанькова", "Катериночкина", "Шагидзянов"];
let jobTitleArr = ["уборщик", "продавец"];
let cakeNameArr = ["наполеон", "радость", "флоренция", "лидер", "часовой", "каприз", "ромашка", "тюльпан", "праздник"];
let cakeTypeArr = ["сметанный", "многослойный", "бисквитный", "муссовый"];
let ingredientsArr = ["мука", "молочный шоколад", "разрыхлитель", "лимонная кислота", "клубничная глазурь", "белый шоколад", "яйцо куриное", "молоко", "сахар"];
Math.random();

function randomDate(start, end, startHour, endHour) {
    var date = new Date(+start + Math.random() * (end - start));
    var hour = startHour + Math.random() * (endHour - startHour) | 0;
    date.setHours(hour);
    return date;
}

let managerArr = [];
let cookArr = [];
let cakeArr = [];

for (i = 0; i < 10; ++i) {
    managerName = nameArr[Math.floor(Math.random() * 100)];
    managerLastname = lastnameArr[Math.floor(Math.random() * 100)];
    let manager = personals.insertOne({
        
        name: managerName,
        lastname: managerLastname,
        jobTitle: "менеджер",
        salary: Math.floor(Math.random() * 50000) + 20000,
        manager: null
    })
    managerArr[i] = (managerName+" " +managerLastname);
 
}

for(i = 0; i < 50; ++i){
    cookName = nameArr[Math.floor(Math.random() * 100)];
    cookLastname = lastnameArr[Math.floor(Math.random() * 100)];
    let cook = personals.insertOne({
        
        name: cookName,
        lastname: cookLastname,
        jobTitle: "повар",
        salary: Math.floor(Math.random() * 50000) + 20000,
        manager: managerArr[Math.floor(Math.random() * 10)],
        
    })
    cookArr[i] =(cookName + " " + cookLastname);
    
    let personal = personals.insertOne({
        
        name: nameArr[Math.floor(Math.random() * 100)],
        lastname: lastnameArr[Math.floor(Math.random() * 100)],
        jobTitle: jobTitleArr[Math.floor(Math.random() * 2)],
        salary: Math.floor(Math.random() * 50000) + 20000,
        manager: managerArr[Math.floor(Math.random() * 10)]

    })

    let ingredient = ingredients.insertOne({
        
        name: ingredientsArr[Math.floor(Math.random() * 9)],
        explorationDate: randomDate(2020 - 07 - 17, 2030 - 07 - 17, 00, 00),
        inStock: `${Math.floor(Math.random() * 200)} кг`,
    })

    cakeName = cakeNameArr[Math.floor(Math.random() * 9)];
    cakeType = cakeTypeArr[Math.floor(Math.random() * 4)];
    let cake = cakes.insertOne({
        
        name: cakeNameArr[Math.floor(Math.random() * 9)],
        type: cakeTypeArr[Math.floor(Math.random() * 4)],
        weight: `${Math.floor(Math.random() * 6) + 1} кг`,
        price: Math.floor(Math.random() * 10000) + 1000,
        ingredients: [
            ingredientsArr[Math.floor(Math.random() * 9)],
            ingredientsArr[Math.floor(Math.random() * 9)],
            ingredientsArr[Math.floor(Math.random() * 9)],
            ingredientsArr[Math.floor(Math.random() * 9)]]
    })
    cakeArr[i] =(cakeName+" " +cakeType );
}

let clientArr = [];
for (i = 0; i < 100; ++i) {
    clientName = nameArr[Math.floor(Math.random() * 100)];
    clientLastname = lastnameArr[Math.floor(Math.random() * 100)];
    let client = clients.insertOne({
        
        name: clientName,
        lastname: clientLastname
    })
    clientArr[i] =(clientName +" " + clientLastname );
    
}

for(i = 0; i < 300; ++i)
{
    let order = orders.insertOne({
        
        client: clientArr[Math.floor(Math.random() * 100)],
        dateOrd: randomDate(2020 - 07 - 17, 2030 - 07 - 17, 00, 00),
        cook: cookArr[Math.floor(Math.random() * 50)],
        cake: cakeArr[Math.floor(Math.random() * 50)],
        price: Math.floor(Math.random() * 10000) + 1000,
        
    })
}


let user1 = users.insertOne({
        
    login: "admin",
    password: "admin",
    token:32534543645,
    tokenDate: new Date("2023-09-21T16:00:00Z")
    
})

let user2 = users.insertOne({
        
    login: "user",
    password: "user",
    token:34657657450,
    tokenDate: new Date("2023-09-21T16:00:00Z")
    
})

let token = tokens.insertOne({
    
    lastUser:"admin",
    token: 1,
    valid: new Date("2022-09-21T16:00:00Z")
    
})
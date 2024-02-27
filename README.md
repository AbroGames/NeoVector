> [!IMPORTANT]
> Перед тем как начинать кодить ограбленные караваны, ознакомься с [Wiki](https://github.com/AbroGames/NeoVector/wiki)

# Внешний цикл

Внешний игровой цикл делится на боевую часть и мирный хаб, где можно улучшать персонажа. 
Игра начинается с мирного хаба, где игроки могут по своему желанию улучшить персонажа, прокачать способности, крафтить предметы и т.д.
Игроки переходят в боевую часть по готовности, которая делится на волны. Если игроки погибают, они возвращаются в мирный хаб. 
Всего в игре n волн, цель: пройти последнюю волну. Определённые волны (например, каждая пятая, но это число может меняться) являются точками сохранения. Если игроки прошли эту волну, то из мирного хаба можно вернуться сразу к сохранённой волне. 

# Боевая часть

Каждая волна начинается с периода длиной n секунд спауна противников. После идёт пауза спауна противников перед следующей волной. У каждой волны эти временные промежутки могут быть разными. В худе должен быть таймер до следующей волны.
Правила спауна у каждой волны свои: какие противники, в каком количестве, в каком месте и в какой момент времени от начала волны. Противники подразделяются на разные типы (штук 30-40), которые имеют разные механики, включая спаун миньонов, строительство стен и т.д. Если к моменту старта новой волны на карте ноль врагов, то игрокам даётся бонус опыта.  
  
Гринд мод -- если прошёл волну, можешь её перепройти для фарма ресов в бесконечном режиме. В этом режиме увеличенный лут.

# Мирный хаб

В мирном хабе можно улучшать статы персонажа, прокачивать скиллы, крафтить снаряжение, обмениваться снаряжением и предметами друг с другом, покупать и продавать вещи. В мирном хабе есть полигон. где стоят все виды противников. По ним можно проверять свой урон и читать описание проитвников, которое появляется после первого убийства. Если противника игрок видел, но ещё не убил, у него есть возомдность разблокировать описание о противнике за плату (возможно, большую).  

# Персонаж

Персонаж состоит из модулей. Есть фиксированные слоты для ног, которые улучшают скорость, руки/спина для оружия, добавляющие скиллы, слот для энергии (реактор), слоты для хп (внешняя броня), слоты для антен, пркоачивающих саммонющую мощь, слоты для генератора материи, улучшающие производственную мощь (для постройки стен и турелей), модули ИИ, прокачивающие ПЮ, слоты для аккумуляторов, прокачивающих количество энергии, слоты для модулей, прокачивающих всё (чип ИИ). В зависимости от класса игрок вынужден прокачивать разные модули:  
1) дд -- генератор энергии, т.к. оружие потребляет много энергии
2) танк -- щиты
3) хил -- модуль ИИ, т.к. оружие хила требует много ПЮ.
4) баффер/дебаффер -- генератор энергии и модуль ИИ, т.к. в равной степени требует и то, и другое в большом количестве (можно добавить ещё что-то, если будет скучно, например, необходима антена и материя для маяков баффа)
5) саммонер -- антена
6) инженер (строит стены и турели) -- генератор материи
  
У модулей есть основные статы и дополнительные. Существуют сабмодули (способ улучшить модули (уменьшить потребление энергии, увеличить основной стат модуля и т.п.)). Сабстаты можно перегениривать за ресурсы (отдельно тип стата и цифру). Число сабмодулей, которые можно повесить на модуль, зависит от модуля (например, его типа или его грейда). И модули, и сабмодули можно улучшать (точить, +1, +2 и т.д.), увеличивая основной стат и сабстаты (умножает на коэффициент (K) диапазон и само значение). Каждую пятую заточку у модуля происходит увеличивание основной характеристики на (кол-во основных характерик + кол-во доп. характеристик) * K * 2  
  
Опыт всем выдаётся за счёт убийства противников, если персонаж в этот момент жив.  

У персонажа есть процесс юниты (ПЮ): это число, которое должно быть больше чем сумма потребляемых процесс юнитов всех модулей. Есть модули ИИ, которые могут увеличить доступные процесс юниты персонажа + можно прокачивать модулями общего типа. Есть сабмодуль на уменьшение потребляемых модулем процесс юнитов.  
  
У персонажа есть энергия: она генерируется генератором энергии и общими модулями, потребляется другими модулями и использованием скиллов. При превышении потребления энергии скиллы стреляют реже, щиты и ноги работают хуже.
  
Есть стандартный корпус: четыре оружия, реактор, корпус (броня), щит, аккумулятор, четыре модуля общего назначения. В процессе игры можно скрафтить новые корпуса, которые могут иметь другую конфигурацию слотов для модулей (любое число слотов любых модулей). Корпуса определяют классы. У хиллов два модуля ИИ, у баффера два реактора и модуля ИИ, у дамагера два реактора, у танка два щита. Корпуса меняются 2-3 раза за игру (стандартный -- херовоклассовый -- специфично классовый)

Каждый корпус имеет небольшие значения всех необходимых параметров (хп корпуса, энергия (хранение и реген), скорость, базовое слабое оружие (которое заменяется, если есть хотя бы одно оружие)).

Статы: ХП, Щит, Реген щита, Процент поглощения урона щитом, КПД щита, Энергия, Реген энергии, Скорость, Вес (больший вес замедляет персонажа), Опыт, PU (Процесс юниты).

Про щиты: 

Параметры щита: Макс хп щита, количество энергии для поддержания щита в секунду, коэффициентом энергоэффективности щита, изменение хп щита при наличии энергии, изменение хп щита при отсутствии энергии, время восстановления щита.
Каждый щит имеет свою полоску хп (shield point). 
Щиты требуют энергию для поддержания своей работы (может быть нулевой, т.е. щит не будет требовать энергии). 
Щиты имеют два параметра количества изменения своего хп за секунду: при наличии энергии и при её отсутствии (обычно отрицательное).
Восстановление щита происходит за счёт энергии, при этом конвертация очков энергии в очки щита определяется коэффициентом энергоэффективности щита (количество потребляемой энергии делённое на количество восстанавливаемых хп щита за секунду).
Когда хп щита достигает 0, ему требуется перезарядка в несколько секунд (восстановление идёт только при наличии энергии на работу).
Типы щитов:
1) Щит, восстанавливающийся даже без энергии (положительное значение регена при отсутствии энергии)
2) Щит, сохраняющий хп без энергии (нулевое значение регена при отсутствии энергии)
3) Щит, уменьшающий хп без энергии (отрицательное значение при отсутсвии энергии)
4) Щит резко теряет все хп при отсутствии энергии.

Про пушки:

Есть пушки на восстановление хп, щита и энергии.

# Скиллы

У персонажа есть скиллы, которые он может назначать на какие-то кнопки (в том числе и на левую кнопку мыши). Любая атака является скиллом. У Скиллов есть время отката, какой-то экшен, и количество энергии на использование. Дефолтный скилл можно использовать без остановки
за счёт базового регена энергии.

# Крафтинг

С противников падают ресурсы. Из них можно крафтить снаряжение, а также проводить перегенерирование статов. 

# Потенциально для расширения

Уровни, + 1 параметр в каждый модуль (кпд и саморазряд аккумуляторов, перегрев генератора, дальность действия антены и т.п.)
 

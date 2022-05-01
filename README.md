# Laboration-3---API

Hämta alla personer i systemet - https://localhost:11111/api/person

Hämta alla intressen som är kopplade till en specifik person - https://localhost:11111/api/interest/1

Hämta alla länkar som är kopplade till en specifik person - https://localhost:11111/api/link/1

Koppla en person till ett nytt intresse - POST https://localhost:11111/api/interest samt
{
    "PersonId": 1,
    "Title": "Träning",
    "Description": "Kul att träna."
}

Lägga in nya länkar för en specifik person och ett specifikt intresse - POST https://localhost:11111/api/link samt
{
    "PersonId": 1,
    "interestId": 3,
    "websiteLink": "www.google.se"
}

Ge möjlighet till den som anropar APIet och efterfrågar en person
att direkt få ut alla intressen och alla länkar
för den personen i en hierarkisk JSON-fil - https://localhost:11111/api/person/1

Ge möjlighet för den som anropar APIet att filtrera vad den får ut, som
en sökning. Exempelvis som jag skickar med “to” till hämtning av alla
personer vill jag ha de som har ett “to” i namnet så som “tobias” eller “tomas”.
Detta kan du sen skapa för alla anropen om du vill. - https://localhost:11111/api/person/search/a 
Den gör ingen skillnad på stor och liten bokstav när man söker.

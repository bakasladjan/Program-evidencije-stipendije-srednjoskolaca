# Informacioni sistem – Višeslojna veb aplikacija

## Opis projekta
Ovaj projekat predstavlja realizaciju informacionog sistema u vidu veb aplikacije, razvijene prema principima višeslojne arhitekture. Cilj sistema je obrada podataka kroz jasno razdvojene slojeve: sloj podataka, poslovne logike, servisni sloj i prezentacioni sloj, uz poštovanje principa objektno-orijentisanog programiranja, SOLID principa i clean code prakse.

Aplikacija je u potpunosti lokalizovana na srpski jezik, uključujući korisnički interfejs i nazive identifikatora u programskom kodu.

---

## Arhitektura sistema

Projekat je realizovan kao **višeslojna veb aplikacija** sa sledećim slojevima:

### 1. Sloj podataka
- Relaciona baza podataka kreirana u **SQL Server Management Studio**
  - 2 međusobno povezane tabele
  - 1 tabela za korisnike
- Primena:
  - Stored procedura
  - Pogleda (VIEW)
  - Transakcija (`BEGIN TRANSACTION / COMMIT / ROLLBACK`)
- Konekcioni string izdvojen u poseban konfiguracioni fajl

Tehnološke komponente:
- C# klase za rad sa podacima
- XML fajlovi za parametre poslovne logike
- XML helper klase

---

### 2. Sloj poslovne logike
- Posebne klase za implementaciju poslovnih pravila
- Ograničenja i automatizmi koji se pozivaju prilikom unosa i obrade podataka
- Parametri poslovne logike definisani u eksternim XML/JSON fajlovima

---

### 3. Sloj servisa
- DTO (Data Transfer Object) klase
- Klase za mapiranje podataka
- Implementacija veb servisa:
  - SOAP servis
- Servisi služe kao međusloj između poslovne logike i prezentacionog sloja

---

### 4. Prezentacioni sloj
- Veb aplikacija
- Prezentaciona logika i korisnički interfejs
- Interfejs u potpunosti na srpskom jeziku
- Dinamički elementi (combo box, tabele, filteri)

---

## Funkcionalni zahtevi

✔ Login forma sa skrivenim unosom lozinke  
✔ Personalizovani meni u zavisnosti od profila korisnika  
✔ Najmanje jedan administratorski profil  
✔ Forma za unos podataka sa dinamičkim combo box-om  
✔ Validacije:
- potpunost podataka  
- ispravnost unosa  
- jedinstvenost zapisa  

✔ Implementacija poslovnih pravila prilikom unosa  
✔ Tabelarni prikaz podataka sa filtriranjem  
✔ Izmena i brisanje zapisa  
✔ Štampa spiska podataka  
✔ Parametarska štampa na osnovu filtera  

---

## Strukturni i tehnički zahtevi

- Višeslojna arhitektura (4 sloja i podslojevi)
- Objektno-orijentisano programiranje:
  - Enkapsulacija
  - Nasleđivanje
  - Polimorfizam (method overloading)
- SOLID principi:
  - Single Responsibility
  - Interfejsi
  - Dependency Injection
- Clean code praksa:
  - Smisleni nazivi klasa, metoda i atributa
  - Uređen i čitljiv kod
  - Komentari (CRC karta za svaku klasu)

---

## Bezbednosne mere

- Skriven unos lozinke prilikom logovanja
- Rad sa sesijama
- Provera aktivne sesije na svakoj stranici
- Kontrola pristupa u zavisnosti od korisničkog profila

---

## Dokumentacija

Uz projekat je priložena kompletna dokumentacija koja obuhvata:

### 1. Analizu poslovnog sistema
- Opis organizacije i poslovnih procesa
- Radna mesta i zaduženja
- Zakonski i interni propisi

### 2. Specifikaciju zahteva
- Profili korisnika
- Ekranske forme
- Tabelarni prikazi i filteri
- Štampe i izveštaji
- Poslovna pravila i ograničenja

### 3. Dizajn sistema
- Model poslovnih procesa
- Use Case dijagrami
- Dijagrami klasa, komponenti i sekvenci
- Konceptualni i fizički model baze podataka

### 4. Implementaciju i testiranje
- Korisničko i tehničko uputstvo
- Test slučajevi ispravnog i neispravnog rada
- SQL skripte
- Primeri koda po slojevima
- Implementacija OOP, SOLID i clean code principa

---

## Korišćene tehnologije

- C#
- .NET (ASP.NET / MVC)
- SQL Server
- XML
- SOAP Web Services

---

## Autor
**Slađan Baka**

---

## Napomena
Projekat je razvijen u edukativne svrhe kao primer kompletne realizacije informacionog sistema prema zadatim funkcionalnim i nefunkcionalnim zahtevima.

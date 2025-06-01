# Gra w kółko i krzyżyk (sieciowa)

## 📌 Opis projektu
Projekt to konsolowa aplikacja w języku C#, która umożliwia rozegranie gry w kółko i krzyżyk na planszy 3x3 przez sieć. Jeden gracz działa jako serwer, a drugi jako klient. Komunikacja odbywa się za pomocą protokołu TCP z wykorzystaniem biblioteki System.Net.Sockets.

## 🎯 Cel projektu
Celem projektu jest stworzenie gry w kółko i krzyżyk działającej w trybie klient-serwer z prostą komunikacją tekstową, obsługiwaną przez konsolę.

## 🛠 Technologie
- **Język:** C#
- **Środowisko:** Visual Studio 2022
- **Typ aplikacji:** Console Application (.NET 6 lub nowszy)
- **Biblioteki:** System.Net.Sockets

## 🚀 Instrukcja uruchomienia
1. Otwórz rozwiązanie w Visual Studio 2022.
2. Znajdź dwa projekty: `Gra w kółko i krzyżyk serwer` oraz `gra w kółko i krzyżyk klient`.
3. Kliknij prawym na rozwiązanie → Właściwości → Projekty startowe → wybierz „Wiele projektów startowych” i ustaw oba na „Start”.
4. Kliknij **Start (zielona strzałka)**.
5. W konsolach serwera i klienta podaj wiersz i kolumnę (np. `0 1`), aby wykonać ruch.
6. Gra toczy się na przemian do momentu wygranej lub remisu.

## 🎮 Opis działania
- Serwer działa jako gracz X, nasłuchując na porcie TCP.
- Klient działa jako gracz O i łączy się z serwerem (domyślnie `127.0.0.1`).
- Oba projekty wymieniają się ruchami poprzez przesyłanie współrzędnych.
- Po każdym ruchu plansza jest aktualizowana i wyświetlana.

## 🔥 Możliwości rozbudowy
- Dodanie obsługi błędów (np. nieprawidłowe współrzędne).
- Dodanie komunikatów o zwycięstwie/remisie.
- Opcja ponownego rozpoczęcia gry.
- Wariant gry w statki.

## 👤 Autor
Autor projektu: [Wpisz swoje imię i nazwisko]

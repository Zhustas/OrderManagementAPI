## Kodėl pasirinkote tokią kodo struktūrą

- Naudojau N-Layer architektūrą, kad kodas būtų išskaidytas yra lygius, o ne į vieną projektą. Taip yra kodas išskaidomas ir tai palengvina jo palaikymą.
- Duomenų modeliams **Product** ir **Order** padariau **Repository** klases. Pasirinkau taip daryti, kad būtų tam tikras sluoksnis tarp kontrolerių ir duomenų prieinamumo.

## Kaip valdote klaidas (pvz., netinkamus duomenis, 404 atvejus)

- Modeliams naudoju duomenų modelių validaciją naudojant atributus.
- Specifinėms klaidoms (pvz., nėra produkto duomenų bazėje) naudoju specifines klaidos išimtis.
- Naudoju globalų išimčių valdymą.

## Kaip išplėstumėte šią sistemą (pvz., pridėtumėte vartotojus, nuolaidas ar statusus)

- Augant duomenų modelių skaičiams, vietoj kuriant kiekvienai **Repository** klasei atskirus interfeisus, būtų galima sukurti vieną bendrą interfeisą. Taip sumažinant failų skaičių.
- Taip pat, augant duomenų modelių skaičiams ir jei reiktų dirbti su keliais modeliais viename prašyme (_request_), galėtume sukurti **Unit of Work** klasę.
- Galėtume pridėti pavyzdžiui verslo logiką tarp **API** ir **DAL**, kuri būtų atsakinga už nuolaidų taikymą.

# NPC

NPC (Nano Pizza order Calculator) è una semplice console application che permette di calcolare il prezzo di una pizza applicando una serie di sconti.

L'applicazione non prevede input esterni, per effettuare varie prove è necessario modificare il file `Program.cs` e ricompilare il progetto.
Lo sviluppo è stato portato avanti basandosi sull'happy path, non sono stati implementati controlli per la gestione di input errati.
Sono stati implementati test di unità per verificare il corretto funzionamento delle funzionalità principali, i test implementati non coprono tutti i casi possibili.

## Parametri di input di un ordine 
* FullPrice => Prezzo totale della pizza
* HasFidelityCard =>  Indica se il cliente possiede la fidelity card
* HasDisability => Indica se il cliente ha una disabilità
* GroupSize => Numero di persone della tavolata
* OrderDateTime => Data e ora dell'ordine
* CustomerAge => Età del cliente

## Configurazione sconti
Gli sconti sono configurabili nel fle appsetting.json nella sezione DiscountConfig.
```json
{
    "DiscountConfig": {
        "FidelityCardDiscountPercentage": 15,
        "DisabilityDiscountPercentage": 90,
        "EarlyOrderDiscount": {
            "LimitHour": 20,
            "Percentage": 10
        },
        "WeekendDiscountPercentage": 10,
        "SeniorCitizenDiscount": {
            "AgeThreshold": 60,
            "Percentage": 70
        },
        "GroupDiscounts": {
            "15-20": 20,
            "21-25": 30,
            "26": 50
        },
        "ChildDiscounts": {
            "0-3": 50,
            "4-11": 20
        }
    }
}



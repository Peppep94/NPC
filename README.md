# NPC

NPC (Nano Pizza order Calculator) � una semplice console application che permette di calcolare il prezzo di una pizza applicando una serie di sconti.

L'applicazione non prevede input esterni, per effettuare varie prove � necessario modificare il file `Program.cs` e ricompilare il progetto.
Lo sviluppo � stato portato avanti basandosi sull'happy path, non sono stati implementati controlli per la gestione di input errati.
Sono stati implementati test di unit� per verificare il corretto funzionamento delle funzionalit� principali, i test implementati non coprono tutti i casi possibili.

## Parametri di input di un ordine 
FullPrice => Prezzo totale della pizza
HasFidelityCard =>  Indica se il cliente possiede la fidelity card
HasDisability => Indica se il cliente ha una disabilit�
GroupSize => Numero di persone della tavolata
OrderDateTime => Data e ora dell'ordine
CustomerAge => Et� del cliente

## Configurazione sconti
Gli sconti sono configurabili nel fle appsetting.json nella sezione DiscountConfig.

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



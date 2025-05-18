module OpilioCraft.DSL.StringTemplate.Main 
// For more information see https://aka.ms/fsharp-console-apps

let placeholderMap : PlaceholderMap =
    Map.ofList
        [
            "name", (fun args -> args.Head)
            "date", (fun _ -> "heute")
        ]

"Hallo {name|Carsten}! Wie war der Tag {date|MM.}?"
|> Runtime.Parse
|> fun st -> Runtime.Eval(placeholderMap, (fun name -> failwith $"unknown placeholder: {name}"), st)
|> System.Console.WriteLine

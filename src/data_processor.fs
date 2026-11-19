open System
open System.IO
open System.Text.Json

type Record = { Id: int; Name: string; Value: float; Category: string }

let parseRecords (path: string) =
    File.ReadAllLines(path)
    |> Array.skip 1
    |> Array.map (fun line ->
        let cols = line.Split(',')
        { Id = int cols.[0]; Name = cols.[1]; Value = float cols.[2]; Category = cols.[3] })

let filterByCategory category (records: Record[]) =
    records |> Array.filter (fun r -> r.Category = category)

let aggregateByCategory (records: Record[]) =
    records
    |> Array.groupBy (fun r -> r.Category)
    |> Array.map (fun (cat, group) ->
        (cat, group.Length, group |> Array.sumBy (fun r -> r.Value)))

[<EntryPoint>]
let main args =
    if args.Length = 0 then
        printfn "Usage: shae-data-processor <csv-file> [category]"
        1
    else
        let records = parseRecords args.[0]
        printfn "Total records: %d" records.Length
        match args with
        | [|_; category|] ->
            let filtered = filterByCategory category records
            printfn "Records in category '%s': %d" category filtered.Length
        | _ ->
            let agg = aggregateByCategory records
            printfn "Category breakdown:"
            for cat, count, total in agg do
                printfn "  %s: %d records, total value %.2f" cat count total
        0

[<RequireQualifiedAccess>]
module Elmish.Vue.Program
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers
open Fable.Helpers.Vue
open Fable.Helpers.Quasar
open Fable.Import


[<Pojo>] type Props = { state: VNodeThunk option }
let [<Import("default","vue")>] vue: Vue.VueConstructorStatic = jsNative

do vue.``use`` (
    quasar,
    createObj [
        "plugins" ==> createObj [ "Notify" ==> notify ]
    ]
)

let withVue element (program:Elmish.Program<_,_,_,_>) =
    let vm: Vue.VueConstructor<Props> =
        vue.Create (
            createObj [
                "props" ==> { state = None }
                "el" ==> U2.Case2 element
                "render" ==> (fun (createElement: Vue.CreateElement) ->
                    let div c = createElement.Invoke (U4.Case1 "div", c)
                    match JsInterop.jsThis<Props>.state with
                    | None -> null
                    | Some (VNodeThunk vNodeThunk) ->
                        match vNodeThunk createElement with
                        | U3.Case1 vNode -> vNode
                        | U3.Case2 string -> U3.Case3 string |> div
                        | U3.Case3 children -> U3.Case1 children |> div
                )
            ] |> unbox
        )
    let setState model dispatch =
        do vm?state <- program.view model dispatch |> Some
    { program with setState = setState }

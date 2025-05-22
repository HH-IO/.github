(**
# HH-IO

Inovação, ciência e tecnologia para saúde mental dimensional  
Membro do Microsoft for Startups Founders Hub  
Stack principal: F#

---

## Sobre a HH-IO

A **HH-IO** é uma organização dedicada à inovação em saúde mental, unindo ciência, tecnologia e humanização.  
Nosso framework principal, **HEALTH/HEALTH**, substitui diagnósticos tradicionais por mapas dimensionais e trajetórias personalizadas, utilizando intensamente F# e paradigmas funcionais.

---

## Fundamentos do domínio

O HEALTH/HEALTH propõe uma abordagem vetorial-dimensional:  
- 10 dimensões fundamentais (emocional, cognitiva, autonomia)
- Foco em trajetórias e transformações ao longo do tempo
- Integração de dados quantitativos, qualitativos e narrativos

---

## Representação das dimensões (tipos F#)
*)
/// As 10 dimensões fundamentais do framework HH
type DimensaoHH =
    | ValenciaEmocional      of int  // -5 a +5
    | ExcitacaoEmocional     of int  // 0 a 10
    | DominanciaEmocional    of int  // 0 a 10
    | IntensidadeAfetiva     of int  // 0 a 10
    | ComplexidadeSintatica  of int  // 0 a 10
    | CoerenciaNarrativa     of int  // 0 a 10
    | FlexibilidadeCognitiva of int  // 0 a 10
    | DissonanciaCognitiva   of int  // 0 a 10
    | PerspectivaTemporal    of int  // 0 a 10
    | Autocontrole           of int  // 0 a 10

(**
---

## Exemplo de perfil dimensional

*)
let perfilExemplo =
    [ ValenciaEmocional 4
      ExcitacaoEmocional 6
      DominanciaEmocional 3
      IntensidadeAfetiva 8
      ComplexidadeSintatica 7
      CoerenciaNarrativa 5
      FlexibilidadeCognitiva 6
      DissonanciaCognitiva 2
      PerspectivaTemporal 7
      Autocontrole 4 ]

(**
---

## Funções reais para manipulação de perfis

Filtra e extrai um valor de dimensão específica:
*)
let encontrarValorDimensao alvo perfil =
    perfil
    |> List.tryPick (function
        | ValenciaEmocional v        when alvo = "ValenciaEmocional"      -> Some v
        | ExcitacaoEmocional v       when alvo = "ExcitacaoEmocional"     -> Some v
        | DominanciaEmocional v      when alvo = "DominanciaEmocional"    -> Some v
        | IntensidadeAfetiva v       when alvo = "IntensidadeAfetiva"     -> Some v
        | ComplexidadeSintatica v    when alvo = "ComplexidadeSintatica"  -> Some v
        | CoerenciaNarrativa v       when alvo = "CoerenciaNarrativa"     -> Some v
        | FlexibilidadeCognitiva v   when alvo = "FlexibilidadeCognitiva" -> Some v
        | DissonanciaCognitiva v     when alvo = "DissonanciaCognitiva"   -> Some v
        | PerspectivaTemporal v      when alvo = "PerspectivaTemporal"    -> Some v
        | Autocontrole v             when alvo = "Autocontrole"           -> Some v
        | _ -> None)

(**
Exemplo de uso:
*)
let valencia = encontrarValorDimensao "ValenciaEmocional" perfilExemplo
// valencia = Some 4

(**
---

## Trajetórias dimensionais

Uma trajetória é uma sequência temporal de perfis dimensionais:
*)
type Trajetoria = DimensaoHH list list

let trajetoriaExemplo : Trajetoria =
    [ perfilExemplo
      [ ValenciaEmocional 2; ExcitacaoEmocional 7; DominanciaEmocional 4
        IntensidadeAfetiva 7; ComplexidadeSintatica 8; CoerenciaNarrativa 6
        FlexibilidadeCognitiva 7; DissonanciaCognitiva 1; PerspectivaTemporal 8; Autocontrole 5 ] ]

(**
Função para calcular a média de cada dimensão ao longo da trajetória:
*)
let mediaDimensao (nome:string) (trajetoria:Trajetoria) =
    trajetoria
    |> List.choose (encontrarValorDimensao nome)
    |> fun vals -> if List.isEmpty vals then None else Some (List.averageBy float vals)

let mediaEmocional = mediaDimensao "ValenciaEmocional" trajetoriaExemplo
// mediaEmocional = Some 3.0

(**
---

## Visualização (exemplo textual)

| Dimensão                | Valor |
|-------------------------|-------|
| Valência Emocional      | 4     |
| Excitação Emocional     | 6     |
| Dominância Emocional    | 3     |
| Intensidade Afetiva     | 8     |
| Complexidade Sintática  | 7     |
| Coerência Narrativa     | 5     |
| Flexibilidade Cognitiva | 6     |
| Dissonância Cognitiva   | 2     |
| Perspectiva Temporal    | 7     |
| Autocontrole            | 4     |

(**
---

## Exemplo avançado: detecção de alerta por dissonância

Função para alertar trajetórias com dissonância cognitiva alta:
*)
let trajetoriasComAlerta (limite:int) (trajetorias:Trajetoria list) =
    trajetorias
    |> List.filter (fun t ->
        t
        |> List.exists (fun perfil ->
            match encontrarValorDimensao "DissonanciaCognitiva" perfil with
            | Some v when v >= limite -> true
            | _ -> false))

// Exemplo: encontra trajetórias que tiveram dissonância >= 5
let trajetoriasAlerta = trajetoriasComAlerta 5 [trajetoriaExemplo]
// Retorna [trajetoriaExemplo] se houver dissonância >= 5

(**
---

## Stack Tecnológica

- **F#** (principal)
- .NET, Chart.js, REST APIs, integração IA (VertexAI, Whisper)
- Infraestrutura cloud, mobile, web e integrações clínicas

---

## Parcerias e Reconhecimento

- Membro do **Microsoft for Startups Founders Hub**
- Colaboração ativa com redes clínicas, pesquisadores e comunidades tecnológicas

---

## Missão, Visão e Valores

- **Missão:** Transformar a prática clínica em saúde mental com tecnologia, rigor científico e interfaces humanizadas.
- **Visão:** Ser referência internacional em frameworks digitais para saúde mental e documentação clínica dimensional.
- **Valores:** Inovação, ética, colaboração, transparência, respeito à singularidade.

---

## Como colaborar

Se você gosta de F#, inovação em saúde, ciência de dados ou design de interfaces, venha colaborar!  
Confira mais detalhes nos repositórios da organização.

---

*Este README está em formato literate F# para engajar devs funcionais, pesquisadores e inovadores.*

*)

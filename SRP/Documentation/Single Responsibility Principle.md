# Princípio da Responsabilidade Única

> “Um módulo deve ter uma, e apenas uma, razão para mudar.”
>
> “Um módulo deve ser responsável por um, apenas um, ator.”

## Conceitos fundamentais

### Ator

Entende-se por *ator* um grupo de pessoas — usuários ou stakeholders — que exige que o sistema mude da mesma forma.

### Módulo

Entende-se por *módulo*, basicamente, um arquivo-fonte.

### Coesão

Coesão é a força que mantém unido o código responsável por atender a um único ator.

Segundo o dicionário Michaelis, *coeso* significa:

- “Firmemente unido ou ligado; associado, coligado.”
- “Que apresenta harmonia; harmônico.”

Segundo o dicionário Michaelis, *harmonia* significa:

- “Disposição equilibrada entre as partes de um todo.”
- “Concordância entre pessoas ou coisas.”

## Violações do SRP

### 1. Duplicação acidental

Essa violação ocorre quando uma classe se torna responsável por mais de um ator.

**Exemplo**

Uma classe `Funcionario` que implementa métodos para diferentes atores, como o RH e a Contabilidade.

A classe passa a acumular responsabilidades e a compartilhar comportamentos e implementações entre métodos e rotinas que não deveriam estar próximos. Atores diferentes solicitam alterações distintas, por motivos distintos. A linguagem utilizada por cada ator também muda: palavras e termos podem ter significados diferentes para cada um deles.

Nesse sentido, é possível estabelecer uma relação com a Linguagem Ubíqua, descrita em *Domain-Driven Design*. Nessa abordagem, o software deve ser modelado e pensado levando em conta os termos definidos pelos especialistas — neste exemplo, os atores —, com atenção especial aos seus significados explícitos e implícitos.

Quando uma classe viola o SRP e contém rotinas que afetam diferentes atores, até mesmo uma pequena alteração pode quebrar partes do sistema que jamais se imaginaria que fossem afetadas. E, pior: isso pode acontecer silenciosamente.

Módulos com milhares de linhas de código, que sustentam telas e mais telas e atendem a inúmeros atores, são uma representação clássica de uma das formas de violação do SRP. Quando uma dessas rotinas precisa ser alterada, nem sempre é possível concluir, de forma razoável, que a mudança não afetará outras partes do sistema.

Além disso, muitas vezes, os testes automatizados são inexistentes. Isso agrava ainda mais a situação, pois não há um mecanismo simples e direto que indique se uma mudança alterou indevidamente o comportamento de outra parte do sistema. Mesmo quando existem testes automatizados, permanece o problema de uma base frágil: rotinas compartilhadas entre contextos diferentes, que mudam e apresentam comportamentos e significados distintos para cada ator.

Voltando ao exemplo anterior, considere a classe `Funcionario`.

Dividir métodos entre a Contabilidade e o RH apenas porque ambos lidam com o conceito de “funcionário” é uma decisão inadequada. Cada ator utiliza os dados de maneiras e para finalidades diferentes, em momentos e cenários distintos.

**Exemplos práticos de diferentes razões para mudança:**

- Leis trabalhistas (Contabilidade)
- Folha de pagamento (Contabilidade)
- Política de benefícios (RH)
- Avaliação de desempenho (RH)

Essa situação resulta em baixa coesão. Contextos completamente diferentes, como cálculo de impostos, rescisões e férias, ficam emaranhados. São contextos distintos reunidos em um mesmo lugar, com métodos e termos compartilhados, mas que não significam as mesmas coisas.

Nesse exemplo, temos a materialização da chamada *God Class*: uma classe inflada, que realiza muitas tarefas e se torna um pesadelo para a manutenção e o desenvolvimento.

**Em resumo, essa primeira violação causa:**

- Múltiplas razões para mudança
- Baixa coesão
- Dificuldade para escrever testes automatizados
- Problemas no versionamento

> “[...] o SRP diz para separar o código do qual diferentes atores dependam.”

### 2. Fusões

Essa violação ocorre quando desenvolvedores diferentes alteram o mesmo arquivo-fonte por motivos distintos, atendendo a solicitações de atores diferentes.

Cada desenvolvedor realiza suas alterações, testa o código e o encaminha para integração. No momento de unir as alterações, surgem conflitos: ambos modificaram as mesmas rotinas, mas com propósitos e resultados diferentes.

Será necessário integrar as alterações. Esse processo pode ser bastante arriscado, pois códigos diferentes, desenvolvidos para solucionar problemas distintos, acabam combinados.

**Consequências:**

- Documentação complexa
- Manutenção complexa
- Dificuldade de compreensão
- Maior acoplamento
- Baixa coesão

## Soluções

De forma geral, o autor sugere separar os dados das funções.

A classe principal `Funcionario` armazena os dados, enquanto classes derivadas podem consumi-los e definir comportamentos. Cada classe derivada não precisa conhecer a existência das demais, isolando os contextos e comportamentos.

## Resultados da aplicação do SRP

- Aumento da coesão, pois cada classe derivada é responsável por apenas um ator.
- Redução de conflitos na integração de código, visto que as rotinas ficam isoladas em arquivos-fonte diferentes.

---

## Referências bibliográficas

### 1. Princípio da Responsabilidade Única (SRP)

MARTIN, Robert C. *Arquitetura Limpa: O Guia do Artesão para Estrutura e Design de Software*. Alta Books, 2019. Parte III, capítulo 7 — **SRP: O Princípio da Responsabilidade Única**.

### 2. Linguagem Ubíqua e Domain-Driven Design (DDD)

EVANS, Eric. *Domain-Driven Design: Atacando as Complexidades no Coração do Software*. 3. ed. rev. Alta Books, 2017. Capítulo 2 — **Comunicação e Uso da Linguagem**.

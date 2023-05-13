
# Título do Projeto

Uma API com projeto de agenda genérica que qualquer pessoa possa utilizar para a sua organização, com o intuito de praticar programação com C# e .NET, ela dispõe de end point's para criação, atualização e exclusão de agendas, e segue com a inclusão de tarefas por agenda junto de atualização das tarefas caso necessário. Neste projeto também foi urilizada o Dapper é um framework de mapeamento objeto-relacional (ORM) para a plataforma .NET. Ele foi projetado para simplificar o acesso a dados em aplicativos .NET, fornecendo uma maneira eficiente e de alto desempenho de mapear objetos em bancos de dados relacionais, juntamente com o banco de dados SQL Server.


# Documentação da API

## Agendas


`http
  GET /api/Agenda/ListarAgendas
`
#### Retorna todos os itens

`http
  POST /api/Agenda/ListarAgenda
`
| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `id` | `int` | **Obrigatório** |

#### Retorna uma agenda específica.


`http
  POST /api/Agenda/InsetAgendas
`
| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `nomeAgenda` | `string` | **Obrigatório** |
| `criadorAgenda` | `string` | **Obrigatório** |

#### Cria uma agenda nova.


`http
  PUT /api/Agenda/AtualizaAgendas
`
| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `id` | `int` | **Obrigatório** |
| `nomeAgenda` | `string` | **Obrigatório** |

#### Atualiza a agenda específicada


`http
  PUT /api/Agenda/DesativaAgendas
`
| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `agendaId` | `int` | **Obrigatório** |

#### Normalmente esse campo seria um "DELETE", porém, por motivos de boas praticas apenas é atualizado um bit de apagado para mantermos um históricos das tarefas.


`http
  GET /api/Tarefas/ListarTarefas
`
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | **Obrigatório** |

#### Lista as tarefas de acordo com o id da tarefa


`http
  POST /api/Tarefas/NovaTarefa
`
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `descricao` | `string` | **Obrigatório** |
| `dataTarefa`| `DateTime` | **Obrigatório** |
| `Status`    | `Bool` | **Obrigatório** |
| `agendaId`  | `int` | **Obrigatório** |

#### Cria uma nova tarefa


`http
  POST /api/Tarefas/NovaTarefa
`
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `agendaId`  | `int` | **Obrigatório** |
| `tarefaId`  | `int` | **Obrigatório** |
| `descricao` | `string` | **Obrigatório** |
| `status`    | `int` | **Obrigatório** |

#### Atualiza a tarefa de acordo com o "tarefaId", o "agendaId", a "descricao" e o "status" da tarefa.




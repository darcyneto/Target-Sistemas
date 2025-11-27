# Target Sistemas - Aplicação ASP.NET Core 8 MVC

Aplicação web completa desenvolvida em ASP.NET Core 8 MVC com Razor Views e jQuery, contendo três módulos distintos para gestão de negócios.

## Tecnologias Utilizadas

- **ASP.NET Core 8** (MVC)
- **C#** 12
- **Razor Views** (.cshtml)
- **jQuery** 3.7.1
- **Bootstrap** 5.3.0
- **Newtonsoft.Json** para persistência de dados

## Estrutura do Projeto

```
Target-Sistemas/
├── Controllers/          # Controladores MVC
├── Models/              # Modelos de dados
├── Services/            # Serviços de negócio e persistência
├── Views/               # Views Razor
├── wwwroot/             # Arquivos estáticos (CSS, JS)
└── Data/                # Arquivos JSON (criado automaticamente)
```

## Módulos

### 1. Comissão de Vendas

Calcula a comissão total de cada vendedor baseado nas vendas realizadas.

**Regras de Comissão:**
- Vendas abaixo de R$ 100,00: **0%** de comissão
- Vendas entre R$ 100,00 e R$ 499,99: **1%** de comissão
- Vendas a partir de R$ 500,00: **5%** de comissão

### 2. Movimentação de Estoque

Gerencia entradas e saídas de produtos no estoque, atualizando automaticamente as quantidades.

**Funcionalidades:**
- Listagem de estoque atual
- Registro de movimentações (Entrada/Saída)
- Validação de estoque suficiente para saídas
- Histórico de movimentações

### 3. Cálculo de Juros

Calcula o valor dos juros de títulos vencidos com multa diária.

**Regra de Cálculo:**
- Multa de **2,5% ao dia** sobre o valor original
- Calculado desde a data de vencimento até a data atual

## Como Executar

1. Certifique-se de ter o .NET 8 SDK instalado
2. Abra o terminal na pasta do projeto
3. Execute os seguintes comandos:

```bash
dotnet restore
dotnet run
```

4. Acesse a aplicação em: `https://localhost:5001` ou `http://localhost:5000`

## Persistência de Dados

A aplicação utiliza arquivos JSON para simular a persistência de dados:
- `Data/vendas.json` - Dados de vendas
- `Data/estoque.json` - Dados de estoque
- `Data/movimentacoes.json` - Histórico de movimentações

Os arquivos são criados automaticamente na primeira execução com dados iniciais.

## Estrutura de Dados

### Vendas
```json
{
  "vendas": [
    { "vendedor": "João Silva", "valor": 1200.50 }
  ]
}
```

### Estoque
```json
{
  "estoque": [
    { "codigoProduto": 101, "descricaoProduto": "Caneta Azul", "estoque": 150 }
  ]
}
```

## Funcionalidades

- ✅ Navegação entre módulos via navbar
- ✅ Validação de formulários no cliente e servidor
- ✅ Interface responsiva com Bootstrap
- ✅ Persistência de dados em arquivos JSON
- ✅ Cálculos automáticos de comissões e juros
- ✅ Gestão completa de movimentações de estoque

## Desenvolvido por

Target Sistemas


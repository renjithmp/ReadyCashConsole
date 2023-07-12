# ReadyCashConsole
dotnet ef migrations add customerTransactions --project CustomerCore/Customer.Core.csproj -s readycashconsole/readycashconsole.csproj  --context CustomerDbContext  --verbose

dotnet ef database update --verbose --context CustomerDbContext --project readycashconsole/readycashconsole.csproj

dotnet ef migrations add firstMigration --project LoanCore/Loan.Core.csproj -s readycashconsole/readycashconsole.csproj    --verbose --context LoanDbContext

dotnet ef database update --verbose --context LoanDbContext --project readycashconsole/readycashconsole.csproj


---kafka commands 

bin/zookeeper-server-start.sh config/zookeeper.properties

bin/kafka-server-start.sh config/server.properties

bin/kafka-topics.sh --list --bootstrap-server localhost:9092

bin/kafka-topics.sh --create --topic ready-cash-loan --bootstrap-server localhost:9092

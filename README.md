# una-sdm-lista-14
Explique no README como uma latência de 2 segundos impactaria um
franqueado tentando fechar um pedido em um tablet na frente do
cliente.

A latência poderia causar a sensação de travamento no sistema e também reduzir a velocidade do atendimento.


4. Pensamento Crítico (README.md):
"Em grandes datas como a Páscoa, a Cacau Show recebe milhares de pedidos
por segundo. Como você evitaria que dois franqueados 'comprassem' o
último lote de Trufas disponível simultaneamente? Pesquise sobre 'Race
Conditions' e como o bloqueio de banco de dados (Locking) resolve isso."


Utilizamos o conceito de Transações Átomicas com Database Locking. Em um cenário de alta concorrência como a Páscoa da Cacau Show, o sistema deve prevenir a Race Condition garantindo que a verificação e a baixa do estoque ocorram de forma isolada. Ao implementar o Pessimistic Locking, o sistema bloqueia o registro do lote no banco de dados no instante em que o primeiro pedido começa a ser processado, impedindo que outras requisições leiam um saldo de estoque que está prestes a ser alterado

select e.assunto, 
       e.ano, 
       count(*)as quantidade  
       
  from atendimentos e 
  
group by  e.assunto, e.ano

HAVING count(*) > 3

order by 3 desc

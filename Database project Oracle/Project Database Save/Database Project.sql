select dummy,
        lpad(dummy,4,'*')
        from dual;
      
select dummy,
       rpad(dummy,4,'*')
       from dual;
       
select ltrim('   Test_trim') X
        from dual;
        
select rtrim('Test_trim     ')
        from dual;
    
select length('Test_trim')
        from dual;
        
select substr('Hello World',2,4) from dual;
        
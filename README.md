Acceptable payloads exp:

json:
curl -X 'POST' \
  'https://localhost:5001/json/Payment/Add' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
   "data":"{\"FirstName\":\"Pedram\",\"LastName\":\"Rangchian\",\"BasicSalary\":\"3000000\",\"Allowance\":\"200000\",\"Transportation\":\"100000\",\"Date\":\"2022-03-12\"}",
  "overTimeCalculator": "CalcurlatorA"
}'

=======================================================================================
xml:
curl -X 'POST' \
  'https://localhost:5001/xml/Payment/Add' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "data":"<root>
  <FirstName>Pedram</FirstName>
  <LastName>Rangchian</LastName>
  <BasicSalary>3000000</BasicSalary>
  <Allowance>200000</Allowance>
  <Transportation>100000</Transportation>
  <Date>2022-03-12</Date>
</root>",
  "overTimeCalculator": "CalcurlatorA"
}'

=======================================================================================
cs:
curl -X 'POST' \
  'https://localhost:5001/cs/Payment/Add' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "data":"FirstName,LastName,BasicSalary,Allowance,Transportation,Date
Pedram,Rangchian,3000000,200000,100000,2022-03-12",
  "overTimeCalculator": "CalcurlatorA"
}'

=======================================================================================
custom:
curl -X 'POST' \
  'https://localhost:5001/custom/Payment/Add' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "data":"FirstName/LastName/BasicSalary/Allowance/Transportation/Date\nAli/Ahmadi/1200000/400000/350000/14010801",
  "overTimeCalculator": "CalcurlatorA"
}'
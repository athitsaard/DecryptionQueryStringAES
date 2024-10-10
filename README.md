คำอธิบาย
project นี้แสดงตัวอย่างการ Decryption QueryString  Url ของ Miniapp เพื่อนำค่า QueryString Parameter ต่างๆไปใช้งาน พัฒนาด้วยภาษา .net 5.0/c# 
โดยมีไฟล์ที่สำคัญในการทำงาน คือ 1.HomeController.cs 2.Helper.cs

ขั้นตอนการทดสอบและการทำงานของโค๊ตตัวอย่าง
1.ให้ทำการ Run project หลังจากนั้นให้นำตัวอย่าง Url "http://localhost:5000/Home/index?q=JHr2ZKQjD4eenerUc%2fWwjnSlRSC1yjNRzHHgcB2ugYfS%2f5e5xgOIExSNNiFqTmyz5u%2bSXI9gcquXz7WsyN5Qw%2b3SmMEeI8qHk057OGcL%2bohA6T2b48N0%2fW0B83U8bPCFahSMcDdDNXVwsDD%2fHaS%2f8cZDyEwZzR0y1LaGgQVVwMoJntVkbVecurGvyKs%2bXoGCs0vLXGcmKSd8Ch2uFk3F9gMGu7bKv8EmLYePxzf63fsSpavPhF8WHeGWgJ6u46pc"
ไปวางใน Address Bar Url ของ ฺBrowser และกด Enter  โดยค่าUrlที่ใส่จะเข้ามาที่ไฟล์ HomeController.cs และ Action Index โดยใน Action Index จะให้มีการใส่ค่าตัวแปร Key และ IV สามารถติดต่อขอค่าตัวแปรจากทีม Bizportal ของ DGA
หลังจากนั้นจะเรียกใช้ Functon Method GetQueryString โดยจะทำการส่งค่า Url / Key / IV  เข้า Functon Method GetQueryString
2.การทำ Decryption จะทำงานที่ไฟล์ Helper.cs โดยจะแสดงรายละเอียด algorithm และการเซตค่าต่างของ algorithm และรายละเอียดการทำงาน ในที่นี้จะใช้ Decryption algorithm คือ AES (Advanced Encryption Standard)







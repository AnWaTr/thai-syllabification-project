# thai-syllabification-project-

In grad school for my 2nd MS I was given a task to parse Thai phrases.  

The interesting thing about Thai is words are strung together in one long blob:

ฉันเห็นเขาตามเธอแจไปทุกทีเป็นเงาตามตัวตลอดเลย
นกเล็กมีหน้าอกสีแดง
เจ้าของโรงงานมองหาที่ตั้งของโรงงานใหม่
ขาของเขาสั่นเทาเมื่อต้องลงมาจากที่สูง
จุดสุดยอดของความรู้สึกทางเพศ
หนึ่งหมื่นสองพันห้าร้อยหกสิบสาม
สองหมื่นสี่พันหนึ่งร้อยห้าสิบสอง
เขาเป็นเพื่อนของฉันมาหลายปีแล้ว
บ้านหลังนั้นไม่ใช่ของเขาเล็กไป
เขาผลัดค่าเช่าห้องมาเดือนหนึ่งแล้ว
ฉันตายด้านในเรื่องความรักเสียแล้วหลังจากที่ฉันเคยผิดหวังกับความรัก

But in reality, these long globs break down to syntactic and semantic details. 

So, I wrote a state machine that broke thing apart and outputed the result to a HTML file with word breaks. 

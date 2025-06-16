;; --- SHABLONY (TEMPLATES) ---
;; Shablon dlya vhodyashih dannyh ot polzovatelya
(deftemplate user_input
    (slot byudzhet (type INTEGER))
    (slot ispolzovanie (type SYMBOL))
    (slot proizvoditelnost (type SYMBOL))
)

;; Shablony dlya komponentov
(deftemplate processor (slot nazvanie (type STRING)))
(deftemplate videokarta (slot nazvanie (type STRING)))
(deftemplate materinskaya_plata (slot nazvanie (type STRING)))
(deftemplate operativnaya_pamyat (slot nazvanie (type STRING)))
(deftemplate nakopitel (slot nazvanie (type STRING)))
(deftemplate blok_pitaniya (slot nazvanie (type STRING)))
(deftemplate korpus (slot nazvanie (type STRING)))

;; Shablon dlya itogovoy rekomendatsii
(deftemplate rekomendatsiya (multislot komponenty))

;; --- PRAVILA (RULES) DLYA VYBORA PROCESSORA ---

(defrule vybor_processora_nizkiy_byudzhet_ofis
    (user_input (byudzhet ?b&:(< ?b 50000)) (ispolzovanie ofis|razrabotka))
    =>
    (assert (processor (nazvanie "Intel Core i3-12100F / AMD Ryzen 5 3600")))
)

(defrule vybor_processora_nizkiy_byudzhet_igry
    (user_input (byudzhet ?b&:(< ?b 50000)) (ispolzovanie igry|kontent))
    =>
    (assert (processor (nazvanie "AMD Ryzen 5 5500")))
)

(defrule vybor_processora_sredniy_byudzhet_ofis
    (user_input (byudzhet ?b&:(>= ?b 50000)&:(< ?b 100000)) (ispolzovanie ofis|razrabotka))
    =>
    (assert (processor (nazvanie "Intel Core i5-12400F / AMD Ryzen 5 5600X")))
)

(defrule vybor_processora_sredniy_byudzhet_igry
    (user_input (byudzhet ?b&:(>= ?b 50000)&:(< ?b 100000)) (ispolzovanie igry|kontent))
    =>
    (assert (processor (nazvanie "AMD Ryzen 7 5700X / Intel Core i5-13400F")))
)

(defrule vybor_processora_vysokiy_byudzhet_razrabotka
    (user_input (byudzhet ?b&:(>= 100000)) (ispolzovanie razrabotka))
    =>
    (assert (processor (nazvanie "AMD Ryzen 7 7700X")))
)

(defrule vybor_processora_vysokiy_byudzhet_igry
    (user_input (byudzhet ?b&:(>= 100000)) (ispolzovanie igry|kontent))
    =>
    (assert (processor (nazvanie "Intel Core i7-13700K / AMD Ryzen 9 7900X")))
)

(defrule vybor_processora_vysokiy_byudzhet_ofis
    (user_input (byudzhet ?b&:(>= 100000)) (ispolzovanie ofis))
    =>
    (assert (processor (nazvanie "Intel Core i5-13600K")))
)

;; --- PRAVILA (RULES) DLYA VYBORA VIDEOKARTY ---

(defrule vybor_videokarty_nizkiy_byudzhet_ofis
    (user_input (byudzhet ?b&:(< ?b 40000)) (ispolzovanie ofis))
    =>
    (assert (videokarta (nazvanie "Vstroennaya v processor / NVIDIA GT 1030")))
)

(defrule vybor_videokarty_nizkiy_byudzhet_igry
    (user_input (byudzhet ?b&:(< ?b 60000)) (ispolzovanie igry|razrabotka))
    =>
    (assert (videokarta (nazvanie "NVIDIA GeForce GTX 1650 Super / AMD Radeon RX 6500 XT")))
)

(defrule vybor_videokarty_sredniy_byudzhet_igry_srednyaya
    (user_input (byudzhet ?b&:(>= 60000)&:(< ?b 100000)) (ispolzovanie igry) (proizvoditelnost srednyaya))
    =>
    (assert (videokarta (nazvanie "NVIDIA GeForce RTX 3060 / AMD Radeon RX 6600 XT")))
)

(defrule vybor_videokarty_sredniy_byudzhet_igry_vysokaya
    (user_input (byudzhet ?b&:(>= 80000)&:(< ?b 120000)) (ispolzovanie igry) (proizvoditelnost vysokaya))
    =>
    (assert (videokarta (nazvanie "NVIDIA GeForce RTX 4060 / AMD Radeon RX 7600")))
)

(defrule vybor_videokarty_sredniy_byudzhet_kontent
    (user_input (byudzhet ?b&:(>= 60000)&:(< ?b 120000)) (ispolzovanie kontent|razrabotka))
    =>
    (assert (videokarta (nazvanie "NVIDIA GeForce RTX 3060 Ti")))
)

(defrule vybor_videokarty_vysokiy_byudzhet_srednyaya
    (user_input (byudzhet ?b&:(>= 120000)) (proizvoditelnost srednyaya))
    =>
    (assert (videokarta (nazvanie "NVIDIA GeForce RTX 4070 / AMD Radeon RX 7700 XT")))
)

(defrule vybor_videokarty_vysokiy_byudzhet_vysokaya
    (user_input (byudzhet ?b&:(>= 150000)) (proizvoditelnost vysokaya))
    =>
    (assert (videokarta (nazvanie "NVIDIA GeForce RTX 4080 / AMD Radeon RX 7900 XTX")))
)

(defrule vybor_videokarty_vysokiy_byudzhet_maksimalnaya
    (user_input (byudzhet ?b&:(>= 200000)) (proizvoditelnost vysokaya))
    =>
    (assert (videokarta (nazvanie "NVIDIA GeForce RTX 4090")))
)

;; --- PRAVILA (RULES) DLYA VYBORA MATERINSKOY PLATY ---

(defrule vybor_materinki_intel_12_13_gen_bazovaya
    (processor (nazvanie ?p&:(or (str-index "i3-12") (str-index "i5-12"))))
    =>
    (assert (materinskaya_plata (nazvanie "Chipset B660/B760")))
)

(defrule vybor_materinki_intel_13_gen_vysokaya
    (processor (nazvanie ?p&:(or (str-index "i7-13") (str-index "i9-13"))))
    =>
    (assert (materinskaya_plata (nazvanie "Chipset Z790")))
)

(defrule vybor_materinki_amd_am4_bazovaya
    (processor (nazvanie ?p&:(or (str-index "Ryzen 5 3") (str-index "Ryzen 5 5"))))
    =>
    (assert (materinskaya_plata (nazvanie "Chipset B450/B550")))
)

(defrule vybor_materinki_amd_am4_vysokaya
    (processor (nazvanie ?p&:(str-index "Ryzen 7 5")))
    =>
    (assert (materinskaya_plata (nazvanie "Chipset X570")))
)

(defrule vybor_materinki_amd_am5
    (processor (nazvanie ?p&:(str-index "Ryzen 7 7")))
    =>
    (assert (materinskaya_plata (nazvanie "Chipset B650/X670")))
)

;; --- PRAVILA (RULES) DLYA OPERATIVNOY PAMYATI (RAM) ---

(defrule vybor_ram_ofis
    (user_input (ispolzovanie ofis))
    =>
    (assert (operativnaya_pamyat (nazvanie "8 GB DDR4")))
)

(defrule vybor_ram_nizkiy_byudzhet
    (user_input (ispolzovanie igry|razrabotka) (byudzhet ?b&:(< ?b 70000)))
    =>
    (assert (operativnaya_pamyat (nazvanie "16 GB DDR4 3200MHz")))
)

(defrule vybor_ram_sredniy_byudzhet
    (user_input (ispolzovanie igry|razrabotka|kontent) (byudzhet ?b&:(>= 70000)&:(< ?b 120000)))
    =>
    (assert (operativnaya_pamyat (nazvanie "32 GB DDR4 3600MHz")))
)

(defrule vybor_ram_vysokiy_byudzhet
    (user_input (byudzhet ?b&:(>= 120000)))
    =>
    (assert (operativnaya_pamyat (nazvanie "32 GB DDR5 6000MHz")))
)

;; --- PRAVILA (RULES) DLYA NAKOPITELYA (STORAGE) ---

(defrule vybor_nakopitelya_ofis
    (user_input (ispolzovanie ofis))
    =>
    (assert (nakopitel (nazvanie "256 GB SSD SATA")))
)

(defrule vybor_nakopitelya_nizkiy_byudzhet
    (user_input (ispolzovanie igry|razrabotka|kontent) (byudzhet ?b&:(< ?b 70000)))
    =>
    (assert (nakopitel (nazvanie "512 GB SSD NVMe")))
)

(defrule vybor_nakopitelya_sredniy_byudzhet
    (user_input (ispolzovanie igry|razrabotka|kontent) (byudzhet ?b&:(>= 70000)&:(< ?b 120000)))
    =>
    (assert (nakopitel (nazvanie "1 TB SSD NVMe")))
)

(defrule vybor_nakopitelya_vysokiy_byudzhet
    (user_input (ispolzovanie igry|razrabotka|kontent) (byudzhet ?b&:(>= 120000)))
    =>
    (assert (nakopitel (nazvanie "2 TB SSD NVMe Gen4")))
)

;; --- PRAVILA (RULES) DLYA BLOKA PITANIYA (PSU) I KORPUSA (CASE) ---

(defrule vybor_psu_case_nizkaya_moshnost
    (videokarta (nazvanie ?gpu&:(or (str-index "GTX 16") (str-index "RX 65"))))
    =>
    (assert (blok_pitaniya (nazvanie "550W Bronze")))
    (assert (korpus (nazvanie "Standartniy ATX Mid-Tower")))
)

(defrule vybor_psu_case_srednyaya_moshnost
    (videokarta (nazvanie ?gpu&:(or (str-index "RTX 3060") (str-index "RTX 4060") (str-index "RX 66") (str-index "RX 76"))))
    =>
    (assert (blok_pitaniya (nazvanie "650W-750W Bronze/Gold")))
    (assert (korpus (nazvanie "ATX Mid-Tower s horoshey ventilyatsiey")))
)

(defrule vybor_psu_case_vysokaya_moshnost
    (videokarta (nazvanie ?gpu&:(or (str-index "RTX 4070") (str-index "RTX 4080") (str-index "RX 77") (str-index "RX 79"))))
    =>
    (assert (blok_pitaniya (nazvanie "850W Gold")))
    (assert (korpus (nazvanie "Prostorniy ATX Full-Tower")))
)

(defrule vybor_psu_case_ultra_moshnost
    (videokarta (nazvanie ?gpu&:(str-index "RTX 4090")))
    =>
    (assert (blok_pitaniya (nazvanie "1000W+ Platinum")))
    (assert (korpus (nazvanie "Premium Full-Tower")))
)

;; --- ITOGOVOE PRAVILO (FINAL RULE) ---
;; Eto pravilo sobiraet vse komponenty v odin fakt "rekomendatsiya"

(defrule sobrat_rekomendatsiyu
    (declare (salience -10)) ; Nizkiy prioritet, chtoby srabotalo poslednim
    ?p <- (processor (nazvanie ?proc))
    ?v <- (videokarta (nazvanie ?gpu))
    ?m <- (materinskaya_plata (nazvanie ?mobo))
    ?r <- (operativnaya_pamyat (nazvanie ?ram))
    ?n <- (nakopitel (nazvanie ?hdd))
    ?b <- (blok_pitaniya (nazvanie ?psu))
    ?k <- (korpus (nazvanie ?case))
    =>
    (assert (rekomendatsiya (komponenty 
        (str-cat "Processor: " ?proc)
        (str-cat "Videokarta: " ?gpu)
        (str-cat "Materinskaya plata: " ?mobo)
        (str-cat "Operativnaya pamyat: " ?ram)
        (str-cat "Nakopitel: " ?hdd)
        (str-cat "Blok pitaniya: " ?psu)
        (str-cat "Korpus: " ?case)
    )))
    (retract ?p ?v ?m ?r ?n ?b ?k) ; Udalyaem promezhutochnye fakty
)
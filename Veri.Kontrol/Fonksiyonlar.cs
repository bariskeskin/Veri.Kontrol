/*
 * Copyright (C) 2018 Barış Keskin, https://bariskeskin.com.tr
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 * Author : Baris Keskin
 * Date   : Jan 1, 2018
 */
namespace Veri.Kontrol
{
    public class Fonksiyonlar
    {
        public string E_Posta(string adres)
        {
            string sonuc = string.Empty;
            bool gecersizkaraktervar = adres.IndexOfAny("[\\~#%$€^'&=*+(){}/:;,<>!? |\"]".ToCharArray()) != -1;
            bool trkaraktervar = adres.IndexOfAny("çğıöşüÇĞİÖŞÜ".ToCharArray()) != -1;
            bool birdenFazlaNoktaVar = adres.Contains("..");
            bool sondaNoktaVar = adres.EndsWith(".");
            bool epostaisaretiyok = !adres.Contains("@");
            int epostaisaretisayac = 0;
            foreach (char c in adres)
                if (c == '@') epostaisaretisayac++;
            if (string.IsNullOrEmpty(adres))
            {
                return sonuc = "E-Posta adresi boş olamaz! Şifrenizi sıfırlamanız gerekirse bu e-posta ile işlem yapılmaktadır.";
            }
            if (epostaisaretiyok || epostaisaretisayac != 1)
            {
                return sonuc = "E-posta adresi bir tane @ karakteri içermelidir.";
            }
            if (gecersizkaraktervar || trkaraktervar)
            {
                return sonuc = "E-posta adresinde lütfen yalnızca küçük harfleri (a-z), rakamları ve nokta işaretini kullanın.";
            }
            if (birdenFazlaNoktaVar)
            {
                return sonuc = "E-posta adresinde birden fazla nokta yan yana olmamalıdır.";
            }
            if (sondaNoktaVar)
            {
                return sonuc = "E-posta adresi sonunda nokta olamaz!";
            }
            return sonuc;
        }
    }
}

function ShowForexRate()
{
	function AddCurrencyRate(Currency, Rate) 
	{
	    document.writeln('<tr><td align="left" class="trtt">&nbsp;', Currency, '</td><td align="right" class="trtt">', Rate, '&nbsp;</td></tr>');
	}
	if (typeof(vForexs[0]) !='undefined' && typeof(vCosts[0]) !='undefined') AddCurrencyRate(vForexs[0], vCosts[0]);
	if (typeof(vForexs[1]) !='undefined' && typeof(vCosts[1]) !='undefined') AddCurrencyRate(vForexs[1], vCosts[1]);
	if (typeof(vForexs[2]) !='undefined' && typeof(vCosts[2]) !='undefined') AddCurrencyRate(vForexs[2], vCosts[2]);
	if (typeof(vForexs[3]) !='undefined' && typeof(vCosts[3]) !='undefined') AddCurrencyRate(vForexs[3], vCosts[3]);
//	if (typeof(vForexs[4]) !='undefined' && typeof(vCosts[4]) !='undefined') AddCurrencyRate(vForexs[4], vCosts[4]);
//	if (typeof(vForexs[5]) !='undefined' && typeof(vCosts[5]) !='undefined') AddCurrencyRate(vForexs[5], vCosts[5]);
//	if (typeof(vForexs[6]) !='undefined' && typeof(vCosts[6]) !='undefined') AddCurrencyRate(vForexs[6], vCosts[6]);
//	if (typeof(vForexs[7]) !='undefined' && typeof(vCosts[7]) !='undefined') AddCurrencyRate(vForexs[7], vCosts[7]);
//	if (typeof(vForexs[8]) !='undefined' && typeof(vCosts[8]) !='undefined') AddCurrencyRate(vForexs[8], vCosts[8]);
//	if (typeof(vForexs[9]) !='undefined' && typeof(vCosts[9]) !='undefined') AddCurrencyRate(vForexs[9], vCosts[9]);
//	if (typeof(vForexs[10]) !='undefined' && typeof(vCosts[10]) !='undefined') AddCurrencyRate(vForexs[10], vCosts[10]);
//	if (typeof(vForexs[11]) !='undefined' && typeof(vCosts[11]) !='undefined') AddCurrencyRate(vForexs[11], vCosts[11]);
//	if (typeof(vForexs[12]) !='undefined' && typeof(vCosts[12]) !='undefined') AddCurrencyRate(vForexs[12], vCosts[12]);
//	if (typeof(vForexs[13]) !='undefined' && typeof(vCosts[13]) !='undefined') AddCurrencyRate(vForexs[13], vCosts[13]);
//	if (typeof(vForexs[14]) !='undefined' && typeof(vCosts[14]) !='undefined') AddCurrencyRate(vForexs[14], vCosts[14]);
	
	/*if (typeof(vForex1) !='undefined' && typeof(vCost1) !='undefined') AddCurrencyRate(vForex1, vCost1);
	if (typeof(vForex2) !='undefined' && typeof(vCost2) !='undefined') AddCurrencyRate(vForex2, vCost2);
	if (typeof(vForex3) !='undefined' && typeof(vCost3) !='undefined') AddCurrencyRate(vForex3, vCost3);
	if (typeof(vForex4) !='undefined' && typeof(vCost4) !='undefined') AddCurrencyRate(vForex4, vCost4);
	if (typeof(vForex5) !='undefined' && typeof(vCost5) !='undefined') AddCurrencyRate(vForex5, vCost5);
	if (typeof(vForex6) !='undefined' && typeof(vCost6) !='undefined') AddCurrencyRate(vForex6, vCost6);
	if (typeof(vForex7) !='undefined' && typeof(vCost7) !='undefined') AddCurrencyRate(vForex7, vCost7);
	if (typeof(vForex8) !='undefined' && typeof(vCost8) !='undefined') AddCurrencyRate(vForex8, vCost8);
	if (typeof(vForex9) !='undefined' && typeof(vCost9) !='undefined') AddCurrencyRate(vForex9, vCost9);
	if (typeof(vForex10)!='undefined' && typeof(vCost10)!='undefined') AddCurrencyRate(vForex10, vCost10);
	if (typeof(vForex11)!='undefined' && typeof(vCost11)!='undefined') AddCurrencyRate(vForex11, vCost11);
	if (typeof(vForex12)!='undefined' && typeof(vCost12)!='undefined') AddCurrencyRate(vForex12, vCost12);
	if (typeof(vForex13)!='undefined' && typeof(vCost13)!='undefined') AddCurrencyRate(vForex13, vCost13);
	if (typeof(vForex14)!='undefined' && typeof(vCost14)!='undefined') AddCurrencyRate(vForex14, vCost14);*/
}
ShowForexRate();
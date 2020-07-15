
var faqs_row = 0;
function addRows() {
    html = '<tr id="faqs-row' + faqs_row + '">';
        html += '<td><select class="browser-default custom-select"><option id="selectFund" selected>Share Name</option><option value="DBS">DBS</option><option value="Singtel">Singtel</option><option value="UOB">UOB</option><option value="OCBC">OCBC</option><option value="Starhub">Starhub</option><option value="SIA">SIA</option><option value="SPH">SPH</option><option value="Venture">Venture</option><option value="Comfort Delgro">Comfort Delgro</option><option value="Citibank">Citibank</option><option value="JPMorgan">JPMorgan</option><option value="Google">Google</option><option value="Microsoft">Microsoft</option><option value="General Motors">General Motors</option><option value="General Electrics">GE</option><option value="IBM">International Business Machines Corporation</option><option value="Uber">Uber Technologies Inc</option><option value="Walmart">Walmart Inc</option><option value="Ford">Ford Industries Inc</option></select></td>';
        html += '<td><select class="browser-default custom-select"><option id="selectFund" selected>ISIN</option><option value="D05.SI">D05.SI - DBS</option><option value="Z74.SI">Z74.SI - Singtel</option><option value="U11.SI">U11.SI - UOB</option><option value="O39.SI">O39.SI - OCBC</option><option value="CC3.SI">CC3.SI - Starhub</option><option value="C6L.SI">C6L.SI - SIA</option><option value="T30.SI">T39.SI - SPH</option><option value="V03.SI">V03.SI - Venture</option><option value="C52.SI">C52.SI - Comfort Delgro</option><option value="C">C - Citibank</option><option value="JPM">JPM - JPMorgan</option><option value="GOOG">GOOG - Google</option><option value="MSFT">MSFT - Microsoft</option><option value="GM">GM - General Motors</option><option value="GE">GE - General Electrics</option><option value="IBM">IBM - International Business Machines Corporation</option><option value="UBER">UBER - Uber Technologies Inc</option><option value="WMT">WMT - Walmart Inc</option><option value="FORD">FORD - Ford Industries Inc</option></select></td>';
        html += '<td><input type="text" placeholder="20%" class="form-control"></td>';
        html += '<td class="mt-10"><button class="badge badge-danger" onclick="$(\'#faqs-row' + faqs_row + '\').remove();"><i class="fa fa-trash"></i> Delete</button></td>';
        html += '</tr>';
    
    $('#faqs tbody').append(html);
    
    faqs_row++;
    }


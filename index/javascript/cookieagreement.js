(function(){
    //cookie agreement message
    var msg = "Sütiket használunk a weboldal működésére. Az oldal böngészésének folytatásával Ön elfogadja a cookie-k használatára vonatkozó szabályzatunkat.";
    var closeBtnMsg = "Rendben";
    var privacyBtnMsg = "Cookie Szabályzat";
    var privacyLink = "cookies.php";
    
    //check if cookie is set
    if(document.cookie){
     var cookieString = document.cookie;
     var cookieList = cookieString.split(";");
     for(x = 0; x < cookieList.length; x++){
       if (cookieList[x].indexOf("OKCookie") != -1){return}; 
     }
    }
    
    var docRoot = document.body;
    var okC = document.createElement("div");
    okC.setAttribute("id", "okCookie");
    var okCp = document.createElement("p");
    var okcText = document.createTextNode(msg); 
    
    //close button
    var okCclose = document.createElement("a");
    var okcCloseText = document.createTextNode(closeBtnMsg);
    okCclose.setAttribute("href", "#");
    okCclose.setAttribute("id", "okClose");
    okCclose.appendChild(okcCloseText);
    okCclose.addEventListener("click", closeCookie, false);
   
    //privacy button
    var okCprivacy = document.createElement("a");
    var okcPrivacyText = document.createTextNode(privacyBtnMsg);
    okCprivacy.setAttribute("href", privacyLink);
    okCprivacy.setAttribute("id", "okCprivacy");
    okCprivacy.appendChild(okcPrivacyText);
    
    //append elements
    okCp.appendChild(okcText);
    okC.appendChild(okCp);
    okC.appendChild(okCclose);
    okC.appendChild(okCprivacy);
    docRoot.appendChild(okC);
    
    okC.classList.add("okcBeginAnimate");
    
    function closeCookie(){
      var cookieExpire = new Date();
      cookieExpire.setFullYear(cookieExpire.getFullYear() +2);
      document.cookie="OKCookie=1; expires=" + cookieExpire.toGMTString() + ";";
      docRoot.removeChild(okC);
    }
    
  })();
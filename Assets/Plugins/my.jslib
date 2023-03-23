mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
    console.Log("Hello, world");
  },
  GetLang : function(){
    var lang = ysdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer, bufferSize);
    return buffer;
  },

  ShowAdv : function(){
  ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          // some action after close
        },
        onError: function(error) {
          // some action on error
        }
    }
})

  },

});
$(window, document, undefined).ready(function () {
    

    if ($("[id$=txtUserName]").val()) {
        $("[id$=txtUserName]").addClass('used');
    }
    else {
        $("[id$=txtUserName]").removeClass('used');
    }


    if ($("[id$=txtPassword]").val()) {
        $("[id$=txtPassword]").addClass('used');
    }
    else {
        $("[id$=txtPassword]").removeClass('used');
    }
    

    
  $('input').blur(function() {
    var $this = $(this);
    if ($this.val())
      $this.addClass('used');
    else
      $this.removeClass('used');
  });

  var $ripples = $('.ripples');

  $ripples.on('click.Ripples', function(e) {

    var $this = $(this);
    var $offset = $this.parent().offset();
    var $circle = $this.find('.ripplesCircle');

    var x = e.pageX - $offset.left;
    var y = e.pageY - $offset.top;

    $circle.css({
      top: y + 'px',
      left: x + 'px'
    });

    $this.addClass('is-active');

  });

  $ripples.on('animationend webkitAnimationEnd mozAnimationEnd oanimationend MSAnimationEnd', function(e) {
  	$(this).removeClass('is-active');
  });

});
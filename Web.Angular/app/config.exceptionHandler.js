angular.module('app')
  .config(function ($provide) {
      $provide.decorator('$exceptionHandler', ['$log', '$delegate',
        function ($log, $delegate) {
            return function (exception, cause) {
                exception.message = "[Error]: " + exception.message;
                if (cause)
                {
                    exception.message += ", [Cause]: " + cause;
                }
                $log.debug(exception.message);
                //LogService.logError(exception.message);
                $delegate(exception, cause);
            };
        }
      ]);
  });
angular.module('angularTodo',[])
var uriapi = "api.php"
function mainController($scope, $http){
	$scope.formData = {}
	$scope.rolData = {}
	$scope.perfils = []

	//$scope.isEdit = false
	// SQL
	
	/*$http.get(uriapi)
		.success(function(data){
			$scope.perfils =JSON.parse(   eval(data)  )
			console.log($scope.perfils)
		})
		.error(function(data){
				console.log('Error post...' + data)
		})*/
	$scope.deleteRol = function(id){
		console.log('Delete:' + id)
		$http.delete(uriapi + '?id='+id)
			.success(function(data){
				//console.log('OK' + data)
				$scope.error_message = data
				$scope.rols()
				/*if(data.statuscode && data.statuscode==0){
					$scope.rols()
				}*/
			})
			.error(function(data){
				$scope.error_message = data
				console.log('Error:' + data)
			})
	}
	$scope.saveRol = function(){
		//console.log($scope.rolData)
		if($scope.rolData.idRol>0){
			console.log($scope.rolData)
			$http.put(uriapi, $scope.rolData)
				.success(function(data){
					$scope.rolData = {}
					//$scope.perfils = data
					$scope.rols()
				})
				.error(function(data){
					error_message = data
				})
		}else{
			console.log("Saving....")
			console.log($scope.rolData)
			$http.post(uriapi, $scope.rolData)
				.success(function(data){
					$scope.rolData = {}
					//$scope.perfils = data
					$scope.rols()
				})
				.error(function(data){
					error_message = data
				})
		}
		
	}
	$scope.rols = function(){
		$http.get(uriapi)
			.success(function(data){
				$scope.perfils = JSON.parse(   eval(data)  )
				console.log($scope.perfils)
			})
			.error(function(data){
					console.log('Error post...' + data)
			})
	}
	
	$scope.editRol = function(rol){
		console.log(rol)
		$scope.rolData = rol
	}
	$scope.rols()
	// end SQL
/*
	// Cuando se cargue la pagina pide a la Api todos los TODOs
	$http.get('/api/todos')
		.success(function(data){
			$scope.todos = data
			console.log(data)
		})
		.error(function(data){
			console.log('Error...' + data)
		})
	// Aniadiendo un TODO
	$scope.createTodo=function(){
		$http.post('/api/todos', $scope.formData)
			.success(function(data){
				$scope.formData = {}
				$scope.todos = data
			})
			.error(function(data){
				console.log('Error post...' + data)
			})
	}
	// Borra un TODO luego de checkearlo como acabado
	$scope.deleteTodo = function(id){
		$http.delete('/api/todos/'+id)
			.success(function(data){
				$scope.todos = data
			})
			.error(function(data){
				console.log('Error delete:'+data)
			})
	}
	*/
}
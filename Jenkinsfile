pipeline {
	agent {
	    node {
            label "master"
            customWorkspace "C:\\Users\\kater\\Documents\\JenkinsWorkspace\\MainSolution\\${env.BUILD_NUMBER}"
        }
	}
	stages {
		stage("Checkout code") {
			steps {
				git branch: 'main', url: 'https://github.com/katerineSalas4789/Fishes.git'    
			}
		}
		stage("NuGet Package Restore") {
		    steps {
		        script {
		            bat 'nuget.exe restore MainSolution.sln'
		        }
		    }
		}
		stage("Build") {
		    steps {
		        script {
                  def msbuild = tool name: 'MSBuild.15.0', type: 'hudson.plugins.msbuild.MsBuildInstallation'
                  bat "\"${msbuild}\\MSBuild.exe\" MainSolution.sln /p:Configuration=Debug /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER} /t:build /restore"
                } 
		    }
		}
		stage('Unit test') {
		    steps {
		        script {
                    def MSTest = tool 'MSTest14.0'
                    dir('AlgorithmsTests/bin/Debug/netcoreapp2.1')
                    {
                        bat "\"${MSTest}\" AlgorithmsTests.dll /logger:trx"
                    }
		        }
		        step([$class: 'MSTestPublisher', testResultsFile:"**/*.trx", failOnError: true, keepLongStdio: true])
		    }
        }
	}
}
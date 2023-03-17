nats-local:
	kubectl port-forward pod/my-nats-0 4222 8222 6222 -n infra
bash-profile:
	sudo vim ~/.bashrc

helm-api:
	helm upgrade -n nats-app --create-namespace -f ./deploy/api_emitter/values.yaml api-emitter ./deploy/api_emitter/ 

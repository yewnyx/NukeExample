FROM ubuntu:22.04

LABEL 'org.opencontainers.image.authors'='yewnyx@yewnyx.xyz'
LABEL 'org.opencontainers.image.description'='Docker image for UnityNukeExample dedicated server.'
LABEL 'org.opencontainers.image.licenses'='MIT'
LABEL 'org.opencontainers.image.url'='https://github.com/yewnyx/UnityNukeExample'

ARG SERVER_EXECUTABLE
ENV SERVER_EXECUTABLE=$SERVER_EXECUTABLE

COPY Game /server

VOLUME /server/shared
WORKDIR /server
ENTRYPOINT ["/bin/sh", "-c", "/server/$SERVER_EXECUTABLE"]


function startMonitor() {
    // Get the target node
    const targetNode = document.getElementById('dynamic');

    // Get the element that we'll output the logs to
    const monitorLog = document.getElementById('monitorLog');

    // Options for the observer (which mutations to observe)
    const config = { attributes: true, childList: true, subtree: true, characterData: true };

    // Callback function to execute when mutations are observed
    const callback = function (mutationsList, observer) {
        const timestamp = new Date().toLocaleString();

        for (let mutation of mutationsList) {
            let textNode = document.createTextNode(`${timestamp} Mutation type: ${mutation.type}`);

            if (mutation.type === 'childList') {
                for (let addedNode of mutation.addedNodes) {
                    textNode.textContent += '\nAdded Node id: ' + addedNode.id;
                    textNode.textContent += '\nAdded Node HTML: ' + addedNode.outerHTML;
                }

                for (let removedNode of mutation.removedNodes) {
                    textNode.textContent += '\nRemoved Node id: ' + removedNode.id;
                    textNode.textContent += '\nRemoved Node HTML: ' + removedNode.outerHTML;
                }

            } else if (mutation.type === 'attributes') {
                textNode.textContent += ', attribute changed: ' + mutation.attributeName;
                textNode.textContent += ', new value: ' + mutation.target.getAttribute(mutation.attributeName);
            } else if (mutation.type === 'characterData') {
                textNode.textContent += ', content changed: ' + mutation.target.data;
            }

            textNode.textContent += '\n\n';
            monitorLog.appendChild(textNode);
        }
    };

    // Create an observer instance linked to the callback function
    const observer = new MutationObserver(callback);

    // Start observing the target node for configured mutations
    observer.observe(targetNode, config);
}

function clearLog() {
    const monitorLog = document.getElementById('monitorLog');
    monitorLog.textContent = '';
}

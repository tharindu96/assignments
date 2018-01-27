PASSWORD = 'HELLOWORLD';

while true
    password = input('Enter Password: ', 's');
    if strcmpi(password, PASSWORD)
        fprintf('All the best. Enjoy Matlab\n');
        break
    end
end